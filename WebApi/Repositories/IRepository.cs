using System;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IRepository<T> where T:DbEntity
    {
        T Find(int id);
        T Find(Predicate<T> predicate);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAllBy(Predicate<T> predicate);
        T Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
