using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Contact.Manager.Users.Infrastructure.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
    }
}