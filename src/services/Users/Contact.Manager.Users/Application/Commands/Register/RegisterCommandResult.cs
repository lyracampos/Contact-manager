using System;
using Contact.Manager.Core.Application;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommandResult : CommandResult
    { 
        public RegisterCommandResult(Guid id, string userName, string token)
        {
            this.Id = id;
            this.UserName = userName;
            this.Token = token;
        }
        public Guid Id { get; }
        public string UserName { get; }
        public string Token { get; }
    }
}