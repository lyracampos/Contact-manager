using System;
using Contact.Manager.Users.Infrastructure.Models;
using MongoDB.Driver;

namespace Contact.Manager.Users.Infrastructure.Context
{
    public class DbContext : IDbContext
    {
        private IMongoDatabase mongoDatabase;
        private bool disposedValue = false;

        public DbContext()
        {
            var connectionString = "<mongodb-connectionstriong";
            var client = new MongoClient(connectionString);
            mongoDatabase = client.GetDatabase("ContactManager");
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return mongoDatabase.GetCollection<User>
                    (nameof(User));
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                mongoDatabase = null;
                disposedValue = true;
            }
        }
    }
}