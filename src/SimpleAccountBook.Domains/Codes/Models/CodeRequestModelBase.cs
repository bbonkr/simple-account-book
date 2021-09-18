using System;

namespace SimpleAccountBook.Domains.Codes.Models
{
    public abstract class CodeRequestModelBase
    {
        public Guid ParentId { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public int Ordinal { get; set; }
    }

    public class CodeInsertRequestModel : CodeRequestModelBase
    {

    }

    public class CodeUpdateRequestModel : CodeRequestModelBase
    {
        public Guid Id { get; set; }
    }

    public class CodeDeleteRequestModel
    {
        public Guid Id { get; set; }
    }
}
