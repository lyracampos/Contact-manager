using System;
using Contact.Manager.Framework.Application;
using Contact.Manager.Users.Domain.Entities;

namespace Contact.Manager.Users.Application.Commands.Register
{
    public class RegisterCommand : ICommand
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

        public User ToUser()
        {
            return new User(this.Name, this.Email, this.Password, this.Birth);
        }
    }
}