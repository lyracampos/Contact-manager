using System;
using Contact.Manager.Framework.Domain;

namespace Contact.Manager.Users.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string email, string password, DateTime birth)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Birth = birth;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime Birth { get; private set; }

        public void Update(string name, DateTime birth)
        {
            this.Name = name;
            this.Birth = birth;
        }
    }
}