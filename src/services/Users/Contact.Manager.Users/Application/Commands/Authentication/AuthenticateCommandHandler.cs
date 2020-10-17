using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Framework.Application;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Authentication
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, CommandResult>
    {
        public Task<CommandResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}