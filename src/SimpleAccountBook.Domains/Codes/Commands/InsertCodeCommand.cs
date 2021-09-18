using MediatR;
using SimpleAccountBook.Domains.Codes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleAccountBook.Domains.Codes.Commands
{
    public class InsertCodeCommand : IRequest<CodeModel>
    {
        public InsertCodeCommand(CodeInsertRequestModel payload)
        {
            Payload = payload;
        }

        public CodeInsertRequestModel Payload { get; }
    }
}
