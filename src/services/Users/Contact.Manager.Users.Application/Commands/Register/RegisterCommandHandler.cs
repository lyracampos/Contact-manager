using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, int>
    {
        public Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}