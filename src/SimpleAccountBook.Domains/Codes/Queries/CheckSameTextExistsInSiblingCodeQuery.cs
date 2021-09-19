using AutoMapper;
using kr.bbon.Core;
using kr.bbon.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Shared;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class CheckSameTextExistsInSiblingCodeQuery  :IRequest<bool>
    {
        public CheckSameTextExistsInSiblingCodeQuery(CheckSameTextExistsInSiblingCodeQueryQueryFilter filter)
        {
            Filter = filter;
        }

        public CheckSameTextExistsInSiblingCodeQueryQueryFilter Filter { get; }
    }

    public class CheckSameTextExistsInSiblingCodeQueryQueryFilter
    {
        public CheckSameTextExistsInSiblingCodeQueryQueryFilter(Guid parentId, string text, bool throwIfExists = false)
        {
            ParentId = parentId;
            Text = text;
            ThrowIfExists = throwIfExists;
        }

        public Guid ParentId { get; }

        public string Text { get; }

        public bool ThrowIfExists { get; }
    }

    public class CheckSameTextExistsInSiblingCodeQueryHandler : RequestHandlerWithDatabaseContextBase<CheckSameTextExistsInSiblingCodeQuery, bool>
    {
        public CheckSameTextExistsInSiblingCodeQueryHandler(
            ApplicationDbContext dbContext, 
            IMapper mapper, 
            IMediator mediator, 
            ILogger<CheckSameTextExistsInSiblingCodeQueryHandler> logger) 
            : base(dbContext, mapper, mediator, logger)
        {
        }

        public override async Task<bool> Handle(CheckSameTextExistsInSiblingCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await DbContext.Codes
                .Where(x => !x.IsDeleted)
                .Where(x => x.ParentId == request.Filter.ParentId)
                .Where(x => x.Text == request.Filter.Text)
                .AnyAsync(cancellationToken);

            if (request.Filter.ThrowIfExists && result)
            {
                throw new ApiException(HttpStatusCode.BadRequest, "The same text entry exists.");
            }

            return result;
        }
    }
}
