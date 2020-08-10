using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Contact.Manager.Users.Application.Commands.Edit
{
    public class EditCommandHandler : IRequestHandler<EditCommad, int>
    {
        public Task<int> Handle(EditCommad request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}