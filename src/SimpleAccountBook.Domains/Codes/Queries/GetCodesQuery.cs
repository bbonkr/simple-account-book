using System;
using System.Linq;
using System.Text;

using MediatR;

using SimpleAccountBook.Domains.Codes.Models;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodesQueryRequestModel : IRequest<IPagedModel<CodeModel>>
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
        
        public int Page { get; set; }

        public int Limit { get; set; }
    }
}
