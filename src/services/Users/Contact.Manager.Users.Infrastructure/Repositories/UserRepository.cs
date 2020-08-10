using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contact.Manager.Users.Domain.Entities;
using Contact.Manager.Users.Domain.Repositories;
using Contact.Manager.Users.Infrastructure.Context;
using MongoDB.Bson;

namespace Contact.Manager.Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext context;

        public UserRepository(IDbContext context)
        {
            this.context = context;   
        }

        public async Task Add(User entity)
        {
            var user = new Models.User();
            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.Birth = entity.Birth;
            await this.context.Users.InsertOneAsync(user);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}