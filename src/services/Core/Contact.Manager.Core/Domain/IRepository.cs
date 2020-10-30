using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Manager.Core.Domain
{
    public interface IRepository<T> where T : Entity
    {
         Task<IEnumerable<T>> GetAll();
         Task<T> GetById(Guid id);
         Task Add(T entity);
         Task Update(T entity);
         Task Delete(Guid id);
    }
}