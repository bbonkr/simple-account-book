using System;

namespace SimpleAccountBook.Domains.Codes.Queries
{
    public class GetCodesQueryFilter
    {
        public Guid? Id { get; set; }

        public string Code { get; set; }

        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 10;
    }
}
