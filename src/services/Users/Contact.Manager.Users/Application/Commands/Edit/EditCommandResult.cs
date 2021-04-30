using System;
using Contact.Manager.Core.Application;

namespace Contact.Manager.Users.Application.Commands.Edit
{
    public class EditCommandResult : CommandResult
    {
        /// <summary>
		/// Identificador do usuário
		/// </summary>
        public EditCommandResult(Guid id, string name, DateTime birth)
        {
            this.Id = id;
            this.Name = name;
            this.Birth = birth;

        }
        public Guid Id { get; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Data de nascimento do usuário
        /// </summary>
        public DateTime Birth { get; }
    }
}