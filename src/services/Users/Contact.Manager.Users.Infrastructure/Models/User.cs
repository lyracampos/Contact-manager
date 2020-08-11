using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Contact.Manager.Users.Infrastructure.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }

        public User MapToDb(Domain.Entities.User user)
        {
            Id = user.Id.ToString();
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Birth = user.Birth;
            return this;
        }

        public Domain.Entities.User MapToDomain()
        {
            var user = new Domain.Entities.User
            (
                this.Name,
                this.Email,
                this.Password,
                this.Birth
            );
            user.Id = Guid.Parse(this.Id);
            return user;
        }
    }
}