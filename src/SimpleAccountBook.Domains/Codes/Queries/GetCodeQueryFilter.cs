using System;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodeQueryFilter
    {
        public Guid? Id { get; set; }

        public string Code { get; set; }
    }
}
