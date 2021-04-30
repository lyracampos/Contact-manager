using System;

namespace Contact.Manager.Users.Application.Queries
{
    public class GetQueryResult
    {
        public GetQueryResult(Guid id, string name, string email, DateTime birth, string userName)
        {
            Id = id;
            Name = name;
            Email = email;
            Birth = birth;
            UserName = userName;
        }

        public Guid Id { get; private set; }
         public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime Birth { get; private set; }
        public string UserName { get; private set; }
    }
}