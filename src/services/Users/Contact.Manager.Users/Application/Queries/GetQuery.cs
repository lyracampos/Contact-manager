using System;
using MediatR;

namespace Contact.Manager.Users.Application.Queries
{
    public class GetQuery : IRequest<GetQueryResult>
    {
        public GetQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}