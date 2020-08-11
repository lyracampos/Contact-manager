using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Authentication
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, bool>
    {
        public Task<bool> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}