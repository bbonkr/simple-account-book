using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using kr.bbon.EntityFrameworkCore.Extensions;
using MediatR;

using Microsoft.EntityFrameworkCore;

using SimpleAccountBook.Data;
using SimpleAccountBook.Domains.Codes.Models;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodesQueryHandler : IRequestHandler<GetCodesQuery, CodesResponseModel>
    {
        public GetCodesQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CodesResponseModel> Handle(GetCodesQuery request, CancellationToken cancellationToken)
        {
            var query = dbContext.Codes
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
                .Select(x => mapper.Map<CodeModel>(x))
                .AsNoTracking()
                .ToPagedModelAsync(request.Filter.Page, request.Filter.Limit, cancellationToken);

            var responseModel = mapper.Map<CodesResponseModel>(result);

            return responseModel;
        }

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
    }
}
