using kr.bbon.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;

namespace SimpleAccountBook.Domains.Codes.Models
{
    public class CodeModel
    {
        public CodeModel()
        {
            Codes = new List<CodeModel>();
        }

        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public int Ordinal { get; set; }

        public IEnumerable<CodeModel> Codes { get; set; }
    }

    public class CodesResponseModel : PagedModel<CodeModel> { }
 
}
