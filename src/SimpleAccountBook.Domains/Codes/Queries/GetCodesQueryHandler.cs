using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using kr.bbon.EntityFrameworkCore.Extensions;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Codes.Models;
using SimpleAccountBook.Domains.Shared;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodesQueryHandler : RequestHandlerWithDatabaseContextBase<GetCodesQuery, CodesResponseModel>
    {
        public GetCodesQueryHandler(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator,
            ILogger<GetCodesQueryHandler> logger)
            : base(dbContext, mapper, mediator, logger) { }

        public override async Task<CodesResponseModel> Handle(GetCodesQuery request, CancellationToken cancellationToken)
        {
            var query = DbContext.Codes
                .Include(x => x.SubCodes)
                .Where(x => !x.IsDeleted)
                .Where(x => x.ParentId == null)
                .AsQueryable();

            if (request.Filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == request.Filter.Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.Filter.Code))
            {
                query = query.Where(x => x.Code == request.Filter.Code);
            }

            var result = await query
                .OrderBy(x => x.Ordinal)
                .Select(x => Mapper.Map<CodeModel>(x))
                .AsNoTracking()
                .ToPagedModelAsync(request.Filter.Page, request.Filter.Limit, cancellationToken);

            var responseModel = Mapper.Map<CodesResponseModel>(result);

            return responseModel;
        }
    }
}
