using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Codes.Queries;
using SimpleAccountBook.Domains.Shared;
using SimpleAccountBook.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Commands
{
    public class DeleteCodeCommandHandler : RequestHandlerWithDatabaseContextBase<DeleteCodeCommand, bool>
    {
        public DeleteCodeCommandHandler(ApplicationDbContext dbContext, IMapper mapper, IMediator mediator, ILogger<DeleteCodeCommandHandler> logger) : base(dbContext, mapper, mediator, logger)
        {
        }

        public override async Task<bool> Handle(DeleteCodeCommand request, CancellationToken cancellationToken)
        {
            var item = await Mediator.Send(new GetCodeQuery(new GetCodeQueryFilter(request.Payload.Id)));

            var entry = Mapper.Map<GeneralCode>(item);

            entry.IsDeleted = true;

            DbContext.Codes.Update(entry);

            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
