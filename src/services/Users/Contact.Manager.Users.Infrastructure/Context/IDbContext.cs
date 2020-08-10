using System;
using Contact.Manager.Users.Infrastructure.Models;
using MongoDB.Driver;

namespace Contact.Manager.Users.Infrastructure.Context
{
    public interface IDbContext : IDisposable
    {
         IMongoCollection<User> Users { get; }
    }
}