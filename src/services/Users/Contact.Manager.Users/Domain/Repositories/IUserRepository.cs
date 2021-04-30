using System;
using System.Threading.Tasks;
using Contact.Manager.Core.Domain;
using Contact.Manager.Users.Domain.Entities;

namespace Contact.Manager.Users.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>, IDisposable
    {
        Task<User> GetByEmail(string email); 
    }
}