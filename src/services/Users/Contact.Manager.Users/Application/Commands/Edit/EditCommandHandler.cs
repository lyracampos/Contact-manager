using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Core.Application;
using Contact.Manager.Users.Domain.Repositories;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Edit
{
    public class EditCommandHandler : IRequestHandler<EditCommand, EditCommandResult>
    {
        private readonly IUserRepository userRepository;

        public EditCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<EditCommandResult> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetById(request.Id);

            if (user == null)
            {
                return null;
            }
            user.Update(request.Name, request.Birth);
            await this.userRepository.Update(user);
            return new EditCommandResult(user.Id, user.Name, user.Birth);
        }
    }
}