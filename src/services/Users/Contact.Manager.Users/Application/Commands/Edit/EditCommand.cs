using System;
using Contact.Manager.Core.Application;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Edit
{
    public class EditCommand : IRequest<EditCommandResult>
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