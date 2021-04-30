using System.Threading;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Repositories;
using MediatR;

namespace Contact.Manager.Users.Application.Queries
{
    public class GetQueryHandler : IRequestHandler<GetQuery, GetQueryResult>
    {
        private readonly IUserRepository userRepository;

        public GetQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<GetQueryResult> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var userDb = await userRepository.GetById(request.Id);
            return new GetQueryResult(userDb.Id, userDb.Name, userDb.Email, userDb.Birth, userDb.Email);
        }
    }
}