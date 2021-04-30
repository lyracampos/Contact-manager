using Contact.Manager.Core.Application;

namespace Contact.Manager.Users.Application.Commands.Authenticate
{
    public class AuthenticateCommandResult : CommandResult
    {
        public AuthenticateCommandResult()
        {
            
        }
        public AuthenticateCommandResult(string userName, string token)
        {
            this.UserName = userName;
            this.Token = token;
        }
        public string UserName { get; }
        public string Token { get; }
    }
}