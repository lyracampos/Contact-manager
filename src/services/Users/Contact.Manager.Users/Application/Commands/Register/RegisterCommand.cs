using System;
using Contact.Manager.Core.Application;
using Contact.Manager.Users.Domain.Entities;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterCommandResult>
    {
        /// <summary>
		/// Nome do usuário
		/// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha de acesso ao portal
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Confirmação da senha para verificação de segurança.
        /// </summary>
        public string PasswordConfirm { get; set; }

        /// <summary>
        /// Data de nascimento do usuário
        /// </summary>
        public DateTime Birth { get; set; }

        public bool PasswordValid()
        {
            if (!string.IsNullOrEmpty(Password) &&
                !string.IsNullOrEmpty(PasswordConfirm))
            {
                return Password.Equals(PasswordConfirm);
            }
            return false;
        }

        public User ToUser()
        {
            return new User(this.Name, this.Email, this.Password, this.Birth);
        }
    }
}