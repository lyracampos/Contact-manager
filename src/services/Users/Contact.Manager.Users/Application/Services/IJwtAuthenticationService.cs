using System;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Entities;

namespace Contact.Manager.Users.Application.Services
{
    public interface IJwtAuthenticationService : IDisposable
    {
        string GenerateToken(User user);
    }
}
