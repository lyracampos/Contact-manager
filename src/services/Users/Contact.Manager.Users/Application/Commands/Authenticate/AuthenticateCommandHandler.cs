using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Users.Application.Services;
using Contact.Manager.Users.Domain.Repositories;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Authenticate
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateCommandResult>
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtAuthenticationService authenticationTokenService;

        public AuthenticateCommandHandler(IUserRepository userRepository, IJwtAuthenticationService authenticationTokenService)
        {
            this.userRepository = userRepository;
            this.authenticationTokenService = authenticationTokenService;
        }

        public async Task<AuthenticateCommandResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetByEmail(request.UserName);

            if (user == null || !request.Password.Equals(user.Password))
            {
                var result = new AuthenticateCommandResult();
                result.NotFound("Usuário e/ou senha inválidos.");
                return result;
            }

            var token = authenticationTokenService.GenerateToken(user);
            return new AuthenticateCommandResult(user.UserName, token);
        }
    }
}