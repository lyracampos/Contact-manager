using System;
using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Repositories;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly IUserRepository userRepository;
        public RegisterCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToUser();
            await userRepository.Add(user);
            return user.Id;
        }
    }
}