using MediatR;
using SimpleAccountBook.Domains.Codes.Models;

namespace SimpleAccountBook.Domains.Codes.Commands
{
    public class UpdateCodeCommand : IRequest<CodeModel>
    {
        public UpdateCodeCommand(CodeUpdateRequestModel payload)
        {
            Payload = payload;
        }

        public CodeUpdateRequestModel Payload { get; }
    }
}
