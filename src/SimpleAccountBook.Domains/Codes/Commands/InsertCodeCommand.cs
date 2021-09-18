﻿using MediatR;
using SimpleAccountBook.Domains.Codes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

    public class InsertCodeCommand: IRequestHandler<InsertCodeCommand, CodeModel>
    {
        public InsertCodeCommand()
        {

        }

        public async Task<CodeModel> Handle(InsertCodeCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
