using System;
using Contact.Manager.Framework.Domain;
using Contact.Manager.Users.Domain.Entities;

namespace Contact.Manager.Users.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>, IDisposable
    {
        
    }
}