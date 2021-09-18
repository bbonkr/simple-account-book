using AutoMapper;
using kr.bbon.Core;
using kr.bbon.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Codes.Models;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodeQueryHandler : IRequestHandler<GetCodeQuery, CodeModel>
    {
        public GetCodeQueryHandler(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger<GetCodeQueryHandler> logger)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CodeModel> Handle(GetCodeQuery request, CancellationToken cancellationToken)
        {
            var query = dbContext.Codes.Where(x => !x.IsDeleted);

            if(request.Filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == request.Filter.Id.Value);
            }

            if(!string.IsNullOrWhiteSpace(request.Filter.Code))
            {
                query = query.Where(x => x.Code == request.Filter.Code);
            }

            var result = await query
                .Select(x => mapper.Map<CodeModel>(x))
                .FirstOrDefaultAsync(cancellationToken);

            if (result == null)
            {
                var error = new ErrorModel
                {
                    Code = $"{HttpStatusCode.NotFound}",
                    Message = "Could not find the data.",
                };
                throw new HttpStatusException<ErrorModel>(HttpStatusCode.NotFound, error.Message, error);
            }

            return result;
        }

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger logger;
    }
}
