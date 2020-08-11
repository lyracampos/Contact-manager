using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Repositories;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Edit
{
    public class EditCommandHandler : IRequestHandler<EditCommad, int>
    {
        private readonly IUserRepository userRepository;

        public EditCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<int> Handle(EditCommad request, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetById(request.Id);

            if (user == null)
            {
                return 0;
            }

            user.Update(request.Name, request.Birth);
            
            await this.userRepository.Update(user);
            return 1;
        }
    }
}