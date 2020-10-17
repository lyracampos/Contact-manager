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
            var connectionString = "mongodb://lyracampos:NpMe7aTkkkk@cluster0-shard-00-00.8hjil.mongodb.net:27017,cluster0-shard-00-01.8hjil.mongodb.net:27017,cluster0-shard-00-02.8hjil.mongodb.net:27017/<dbname>?ssl=true&replicaSet=atlas-pb9pc3-shard-0&authSource=admin&retryWrites=true&w=majority";
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