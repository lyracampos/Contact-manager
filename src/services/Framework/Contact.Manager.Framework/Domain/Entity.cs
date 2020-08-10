using System;

namespace Contact.Manager.Framework.Domain
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            WhenCreated = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; private set; }
    }
}