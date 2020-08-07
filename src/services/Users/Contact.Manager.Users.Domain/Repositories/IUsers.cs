using System;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Entities;
namespace Contact.Manager.Users.Domain.Repositories
{
    public interface IUsers : IDisposable
    {
         Task<User> GetByEmail(string email);

         Task<User> Add(User user);

         Task<User> Edit(User user);
    }
}