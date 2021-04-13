using System;

namespace SimepleAccountBook.App.Domains.Codes
{
    public class CodeModel
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public int Ordinal { get; set; }
    }
}
