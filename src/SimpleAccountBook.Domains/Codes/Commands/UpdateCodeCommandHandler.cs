using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Codes.Models;
using SimpleAccountBook.Domains.Codes.Queries;
using SimpleAccountBook.Domains.Shared;
using SimpleAccountBook.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Commands
{
    public class UpdateCodeCommandHandler : RequestHandlerWithDatabaseContextBase<UpdateCodeCommand, CodeModel>
    {
        public UpdateCodeCommandHandler(
           ApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator,
            ILogger<UpdateCodeCommandHandler> logger)
            : base(dbContext, mapper, mediator, logger) { }

        public override async Task<CodeModel> Handle(UpdateCodeCommand request, CancellationToken cancellationToken)
        {
            var parentExists = await Mediator.Send(
                new CheckParentCodeExistsQuery(
                    new CheckParentCodeExistsQueryFilter(request.Payload.ParentId, true)), cancellationToken);

            var hasSameText = await Mediator.Send(
                new CheckSameTextExistsInSiblingCodeQuery(
                    new CheckSameTextExistsInSiblingCodeQueryQueryFilter(request.Payload.ParentId, request.Payload.Text.Trim(), true)), cancellationToken);

            var hadEntry = await Mediator.Send(new GetCodeQuery(new GetCodeQueryFilter(request.Payload.Id)));

            var entry = Mapper.Map<GeneralCode>(request.Payload);

            var addedEntry = DbContext.Codes.Update(entry).Entity;

            await DbContext.SaveChangesAsync(cancellationToken);

            // Adjust code ordianl.

            var result = Mapper.Map<CodeModel>(addedEntry);

            return result;
        }
    }
}
