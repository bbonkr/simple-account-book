using AutoMapper;
using kr.bbon.Core;
using kr.bbon.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Codes.Models;
using SimpleAccountBook.Domains.Shared;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodeQueryHandler : RequestHandlerWithDatabaseContextBase<GetCodeQuery, CodeModel>
    {
        public GetCodeQueryHandler(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator,
            ILogger<GetCodeQueryHandler> logger)
            : base(dbContext, mapper, mediator, logger) { }

        public override async Task<CodeModel> Handle(GetCodeQuery request, CancellationToken cancellationToken)
        {
            var query = DbContext.Codes.Where(x => !x.IsDeleted);

            if(request.Filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == request.Filter.Id.Value);
            }

            if(!string.IsNullOrWhiteSpace(request.Filter.Code))
            {
                query = query.Where(x => x.Code == request.Filter.Code);
            }

            var result = await query
                .Select(x => Mapper.Map<CodeModel>(x))
                .FirstOrDefaultAsync(cancellationToken);

            if (result == null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "Could not find the data.");
            }

            return result;
        }

    }
}
