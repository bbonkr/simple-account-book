using System;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodeQueryFilter
    {
        private GetCodeQueryFilter() { }

        public GetCodeQueryFilter(Guid id)
        {
            Id = id;
        }

        public GetCodeQueryFilter(string code)
        {
            Code = code;
        }

        public Guid? Id { get; set; }

        public string Code { get; set; }
    }
}
