using System;
using Contact.Manager.Framework.Application;

namespace Contact.Manager.Users.Application.Commands.Edit
{
    public class EditCommad : ICommand
    {
        /// <summary>
		/// Identificador do usuário
		/// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Data de nascimento do usuário
        /// </summary>
        public DateTime Birth { get; set; }
    }
}