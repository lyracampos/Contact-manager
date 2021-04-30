using MediatR;

namespace Contact.Manager.Core.Application
{
    public interface ICommand : IRequest<int>
    {
        
    }
}