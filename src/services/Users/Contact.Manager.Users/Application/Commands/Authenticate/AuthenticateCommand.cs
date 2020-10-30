using MediatR;

namespace Contact.Manager.Users.Application.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<AuthenticateCommandResult>
    {
        /// <summary>
        /// Login do usuário
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Senha de acesso
        /// </summary>
        public string Password { get; set; }
    }
}