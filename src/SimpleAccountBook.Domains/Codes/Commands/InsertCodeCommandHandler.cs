using AutoMapper;
using kr.bbon.Core;
using kr.bbon.Core.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Codes.Models;
using SimpleAccountBook.Domains.Codes.Queries;
using SimpleAccountBook.Domains.Shared;
using SimpleAccountBook.Entities;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Commands
{
    public class InsertCodeCommandHandler: RequestHandlerWithDatabaseContextBase<InsertCodeCommand, CodeModel>
    {
        public InsertCodeCommandHandler(
           ApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator,
            ILogger<InsertCodeCommandHandler> logger)
            : base(dbContext, mapper, mediator, logger) { }

        public override async Task<CodeModel> Handle(InsertCodeCommand request, CancellationToken cancellationToken)
        {
            var parentExists = await Mediator.Send(
                new CheckParentCodeExistsQuery(
                    new CheckParentCodeExistsQueryFilter(request.Payload.ParentId, true)), 
                cancellationToken);

            var hasSameText = await Mediator.Send(
                new CheckSameTextExistsInSiblingCodeQuery(
                    new CheckSameTextExistsInSiblingCodeQueryQueryFilter(request.Payload.ParentId, request.Payload.Text.Trim(), true)), 
                cancellationToken);

            var entry = Mapper.Map<GeneralCode>(request.Payload);

            var addedEntry = DbContext.Codes.Add(entry).Entity;

            await DbContext.SaveChangesAsync(cancellationToken);

            // Adjust code ordianl.

            var result = Mapper.Map<CodeModel>(addedEntry);

            return result;
        }
    }
}
