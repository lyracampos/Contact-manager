using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Users.Framework.Application;
using Contact.Manager.Users.Domain.Repositories;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Edit
{
    public class EditCommandHandler : IRequestHandler<EditCommad, CommandResult>
    {
        private readonly IUserRepository userRepository;

        public EditCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<CommandResult> Handle(EditCommad request, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetById(request.Id);

            if (user == null)
            {
                return new CommandResult().NotFound("Usuário não encontrado.");
            }
            user.Update(request.Name, request.Birth);
            await this.userRepository.Update(user);
            return new CommandResult();
        }
    }
}