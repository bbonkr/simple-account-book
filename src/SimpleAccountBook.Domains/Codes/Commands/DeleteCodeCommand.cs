using MediatR;
using SimpleAccountBook.Domains.Codes.Models;

namespace SimpleAccountBook.Domains.Codes.Commands
{
    public class DeleteCodeCommand : IRequest<bool>
    {
        public DeleteCodeCommand(CodeDeleteRequestModel payload)
        {
            Payload = payload;
        }

        public CodeDeleteRequestModel Payload { get; }
    }
}
