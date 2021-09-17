using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using kr.bbon.AspNetCore;
using kr.bbon.AspNetCore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SimpleAccountBook.Data;
using SimpleAccountBook.Entities;

namespace SimpleAccountBook.App.Domains.Codes
{
    public class CodeDomainService : DomainServiceBase
    {
        public CodeDomainService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            logger = loggerFactory.CreateLogger<CodeDomainService>();
        }

        public async Task<IEnumerable<CodeModel>> GetCodesAsync(CancellationToken cancellationToken = default)
        {
            var query = dbContext.Codes
                .Where(x => !x.IsDeleted && x.ParentId == null)
                .OrderBy(x => x.Ordinal)
                .Select(x => mapper.Map<CodeModel>(x))
                .AsNoTracking();

            var result = await query.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<CodeModel>> GetSubcodesAsync(Guid parentId, CancellationToken cancellationToken = default)
        {
            var query = dbContext.Codes
                .Include(x => x.Parent)
                .Where(x => !x.IsDeleted && x.Parent != null && !x.Parent.IsDeleted && x.ParentId == parentId)
                .OrderBy(x => x.Ordinal)
                .Select(x => mapper.Map<CodeModel>(x))
                .AsNoTracking();

            var result = await query.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<CodeModel>> GetSubcodesAsync(string parentCode, CancellationToken cancellationToken = default)
        {
            var query = dbContext.Codes
                .Include(x => x.Parent)
                .Where(x => !x.IsDeleted && x.Parent != null && !x.Parent.IsDeleted && x.Parent.Code == parentCode)
                .OrderBy(x => x.Ordinal)
                .Select(x => mapper.Map<CodeModel>(x))
                .AsNoTracking();

            var result = await query.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<CodeModel> InsertAsync(InsertCodeModel model, CancellationToken cancellationToken =default)
        {
            var statusCode = HttpStatusCode.Created;
            var message = "";

            if (string.IsNullOrWhiteSpace(model.Code))
            {
                statusCode = HttpStatusCode.BadRequest;
                message = $"Code is required.";
                ThrowHttpStatusException(statusCode, message);
            }

            if (string.IsNullOrWhiteSpace(model.Text))
            {
                statusCode = HttpStatusCode.BadRequest;
                message = $"Text is required.";
                ThrowHttpStatusException(statusCode, message);
            }

            var codeEntity = await dbContext.Codes.Where(x => x.Code == model.Code).FirstOrDefaultAsync(cancellationToken);

            if (codeEntity != null)
            {
                statusCode = HttpStatusCode.NotAcceptable;
                message = $"Code '{model.Code}' is not acceptable.";
                ThrowHttpStatusException(statusCode, message);
            }

            Guid? parentId = model.ParentId.HasValue && model.ParentId.Value != Guid.Empty ? model.ParentId.Value : null;

            if (parentId.HasValue)
            {
                var parentCodeEntity=await dbContext.Codes.Where(x => x.Id == parentId).FirstOrDefaultAsync(cancellationToken);
                if(parentCodeEntity == null)
                {
                    statusCode = HttpStatusCode.NotFound;
                    message = $"Parent Code '{parentId}' does not exist.";
                    ThrowHttpStatusException(statusCode, message);
                }
            }

            var newCode = new GeneralCode
            {
                Code = model.Code.Trim(),
                Text = model.Text.Trim(),
                Ordinal = model.Ordinal,
                ParentId = parentId,
            };

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                var codes = dbContext.Codes.Where(x => x.ParentId == parentId && x.Ordinal >= model.Ordinal);

                try
                {
                    foreach (var code in codes)
                    {
                        code.Ordinal = code.Ordinal + 1;
                    }

                    await dbContext.SaveChangesAsync(cancellationToken);

                    var addedCode = dbContext.Codes.Add(newCode).Entity;

                    await dbContext.SaveChangesAsync(cancellationToken);

                    codes = dbContext.Codes.Where(x => !x.IsDeleted && x.ParentId == parentId).OrderBy(x => x.Ordinal);
                    
                    var ordinal = 1;
                    foreach (var code in codes)
                    {
                        code.Ordinal = ordinal;
                        ordinal++;
                    }

                    await dbContext.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);

                    return mapper.Map<CodeModel>(addedCode);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    logger.LogError(ex, ex.Message);
                    throw;
                }
            }
        }

        public async Task<CodeModel> UpdateAsync(UpdateCodeModel model, CancellationToken cancellationToken = default)
        {
            var statusCode = HttpStatusCode.Accepted;
            var message = "";

            if (string.IsNullOrWhiteSpace(model.Code))
            {
                statusCode = HttpStatusCode.BadRequest;
                message = $"Code is required.";
                ThrowHttpStatusException(statusCode, message);
            }

            if (string.IsNullOrWhiteSpace(model.Text))
            {
                statusCode = HttpStatusCode.BadRequest;
                message = $"Text is required.";
                ThrowHttpStatusException(statusCode, message);
            }

            var codeEntity = await dbContext.Codes.Where(x => x.Code == model.Code).FirstOrDefaultAsync(cancellationToken);

            if (codeEntity == null)
            {
                statusCode = HttpStatusCode.NotFound;
                message = $"Code '{model.Code}' does not exist.";
                ThrowHttpStatusException(statusCode, message);
            }

            Guid? parentId = model.ParentId.HasValue && model.ParentId.Value != Guid.Empty ? model.ParentId.Value : null;

            if (parentId.HasValue)
            {
                var parentCodeEntity = await dbContext.Codes.Where(x => x.Id == parentId).FirstOrDefaultAsync(cancellationToken);
                if (parentCodeEntity == null)
                {
                    statusCode = HttpStatusCode.NotFound;
                    message = $"Parent Code '{parentId}' does not exist.";
                    ThrowHttpStatusException(statusCode, message);
                }
            }

            using (var transaction = dbContext.Database.BeginTransaction())
            {

                codeEntity.Code = model.Code.Trim();
                codeEntity.Text = model.Text.Trim();
                codeEntity.Ordinal = model.Ordinal;
                codeEntity.ParentId = parentId;
                codeEntity.UpdatedAt = DateTimeOffset.UtcNow;
                codeEntity.IsDeleted = false;
                codeEntity.DeletedAt = null;

                try
                {
                    await dbContext.SaveChangesAsync(cancellationToken);

                    var codes = dbContext.Codes.Where(x => !x.IsDeleted && x.ParentId == parentId && x.Ordinal >= model.Ordinal && x.Id != model.Id);

                    foreach (var code in codes)
                    {
                        code.Ordinal = code.Ordinal + 1;
                    }

                    await dbContext.SaveChangesAsync(cancellationToken);

                    codes = dbContext.Codes.Where(x => !x.IsDeleted && x.ParentId == parentId);

                    var ordinal = 1;
                    foreach (var code in codes)
                    {
                        code.Ordinal = ordinal;
                        ordinal++;
                    }

                    await dbContext.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);

                    return mapper.Map<CodeModel>(codeEntity);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);

                    logger.LogError(ex, ex.Message);
                    throw;
                }
            }
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var statusCode = HttpStatusCode.Accepted;
            var message = "";

            var candidate = await dbContext.Codes
                .Include(x => x.SubCodes)
                .Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync(cancellationToken);

            if (candidate == null)
            {
                statusCode = HttpStatusCode.NotFound;
                message = $"Code '{id}' does not exist.";

                ThrowHttpStatusException(statusCode, message);
            }

            var now = DateTimeOffset.UtcNow;

            foreach (var code in candidate.SubCodes)
            {
                code.IsDeleted = true;
                code.DeletedAt = now;
            }

            candidate.IsDeleted = true;
            candidate.DeletedAt = now;

            try
            {
                await dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        //private void ThrowHttpStatusException(HttpStatusCode statusCode, string message)
        //{
        //    var error = new ErrorModel
        //    {
        //        Code = $"{statusCode}",
        //        Message = message,
        //    };

        //    throw new HttpStatusException<ErrorModel>(statusCode, message, error);
        //}

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger logger;
    }

    public class InsertCodeModel
    {
        public string Code { get; set; }

        public string Text { get; set; }

        public Guid? ParentId { get; set; }
     
        public int Ordinal { get; set; }
    }

    public class UpdateCodeModel: InsertCodeModel
    {
        public Guid Id { get; set; }
    }
}
