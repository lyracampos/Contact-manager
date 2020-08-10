using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Entities;
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
            var user = new User(request.Name, request.Email, request.Password, request.Birth);
            await userRepository.Add(user);
            return 1;
            //return null
        }
    }
}