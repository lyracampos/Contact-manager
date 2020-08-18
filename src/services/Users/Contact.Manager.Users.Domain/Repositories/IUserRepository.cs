using System;
using Contact.Manager.Users.Framework.Domain;
using Contact.Manager.Users.Domain.Entities;

namespace Contact.Manager.Users.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>, IDisposable
    {
        
    }
}