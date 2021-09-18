using System.Linq;
using System.Text;
using kr.bbon.EntityFrameworkCore.Extensions;
using MediatR;

using SimpleAccountBook.Domains.Codes.Models;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodesQuery : IRequest<CodesResponseModel>
    {
        public GetCodesQuery(GetCodesQueryFilter filter)
        {
            Filter = filter;
        }

        public GetCodesQueryFilter Filter { get; init; }
    }
}
