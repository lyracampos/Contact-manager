using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Repositories;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, int>
    {
        private readonly IUserRepository userRepository;
        public RegisterCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // validar regras de negócio.
            
            var user = request.ToUser();
            await userRepository.Add(user);
            return 1;
        }
    }
}