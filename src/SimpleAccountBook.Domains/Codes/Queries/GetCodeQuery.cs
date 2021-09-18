using MediatR;

using SimpleAccountBook.Domains.Codes.Models;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodeQuery : IRequest<CodeModel>
    {
        public GetCodeQuery(GetCodeQueryFilter filter)
        {
            Filter = filter;
        }

        public GetCodeQueryFilter Filter { get; }
    }
}
