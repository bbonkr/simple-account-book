using AutoMapper;
using kr.bbon.Core;
using kr.bbon.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class CheckParentCodeExistsQuery : IRequest<bool>
    {
        public CheckParentCodeExistsQuery(CheckParentCodeExistsQueryFilter filter)
        {
            Filter= filter;
        }

        public CheckParentCodeExistsQueryFilter Filter { get; }
    }

    public class CheckParentCodeExistsQueryFilter
    {
        public CheckParentCodeExistsQueryFilter(Guid parentId, bool throwIfNotExists = false)
        {
            ParentId = parentId;
            ThrowIfNotExists = throwIfNotExists;
        }

        public Guid ParentId { get; }

        public bool ThrowIfNotExists { get; } 
    }

    public class CheckParentCodeExistsQueryHandler : RequestHandlerWithDatabaseContextBase<CheckParentCodeExistsQuery, bool>
    {
        public CheckParentCodeExistsQueryHandler(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator,
            ILogger<CheckParentCodeExistsQueryHandler> logger)
            : base(dbContext, mapper, mediator, logger)
        {
        }

        public override async Task<bool> Handle(CheckParentCodeExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await DbContext.Codes.Where(x => !x.IsDeleted)
                .Where(x => x.ParentId == request.Filter.ParentId)
                .AnyAsync(cancellationToken);

            if (request.Filter.ThrowIfNotExists && !result)
            {
                throw new ApiException(HttpStatusCode.BadRequest, "Parent code should be exists.");
            }

            return result;
        }
    }
}
