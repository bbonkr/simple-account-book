using System;
using System.Linq;
using System.Text;
using kr.bbon.EntityFrameworkCore.Extensions;
using MediatR;

using SimpleAccountBook.Domains.Codes.Models;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodesQueryRequestModel : IRequest<CodesResponseModel>
    {
        public GetCodesQueryRequestModel(GetCodeQueryFilter filter)
        {
            Filter = filter;
        }

        public GetCodeQueryFilter Filter { get; init; }
    }

    public class GetCodeQueryFilter
    {
        public Guid? Id { get; set; }

        public string Code { get; set; }

        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 10;
    }
}
