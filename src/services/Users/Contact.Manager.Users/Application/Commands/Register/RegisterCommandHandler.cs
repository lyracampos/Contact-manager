using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Core.Application;
using Contact.Manager.Users.Application.Services;
using Contact.Manager.Users.Domain.Repositories;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtAuthenticationService authenticationTokenService;
        
        public RegisterCommandHandler(
            IUserRepository userRepository,
            IJwtAuthenticationService authenticationTokenService)
        {
            this.userRepository = userRepository;
            this.authenticationTokenService =authenticationTokenService;
        }
        public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToUser();
            await userRepository.Add(user);
            var token = authenticationTokenService.GenerateToken(user);
            var result = new RegisterCommandResult(user.Id, user.UserName, token);
            result.Created();
            return result;
        }
    }
}