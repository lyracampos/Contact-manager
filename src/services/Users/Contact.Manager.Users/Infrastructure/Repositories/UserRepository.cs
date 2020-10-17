using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Entities;
using Contact.Manager.Users.Domain.Repositories;
using Contact.Manager.Users.Infrastructure.Context;
using MongoDB.Driver;

namespace Contact.Manager.Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext context;
        private bool disposedValue = false;

        public UserRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetById(Guid id)
        {
            var userDb = await this.context.Users.Find(p => p.Id == id.ToString()).SingleOrDefaultAsync();
            return userDb.MapToDomain();
        }

        public async Task Add(User entity)
        {
            var user = new Models.User().MapToDb(entity);
            await this.context.Users.InsertOneAsync(user);
        }

        public async Task Update(User entity)
        {
            var user = new Models.User().MapToDb(entity);
            FilterDefinition<Models.User> filter = Builders<Models.User>.Filter.Eq(p => p.Id, user.Id);
            await this.context.Users.ReplaceOneAsync(filter, user);
        }

        public Task Delete(Guid id)
        {
            return null;
            //var queryDb = await dbContext.Parceiros.FindAsync(s => s.CpfCnpj.Equals(cpfCnpj));
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
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
                if (disposing)
                {
                    context?.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}