
using System;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
{
    abstract public class Repository<T> : IRepository<T> where T : DbEntity
    {
        List<T> entities = new List<T>();

        private int currentId = 1;
        public int CurrentId
        {
            set { currentId = value; }
            get { return currentId; }
        }

        public T Add(T entity)
        {
            entity.Id = CurrentId++;
            entities.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public T Find(int id)
        {
            var entity = entities.Find(c => { return c.Id == id; });
            return entity;
        }

        public T Find(Predicate<T> predicate)
        {
            var entity = entities.Find(predicate);
            return entity;
        }

        public IEnumerable<T> FindAll()
        {
            return entities;
        }

        public IEnumerable<T> FindAllBy(Predicate<T> predicate)
        {
            var entitiesFromDb = entities.FindAll(predicate);
            return entitiesFromDb;
        }

        public void Update(T newEntity)
        {
            var oldEntity = Find(newEntity.Id);
            entities.Remove(oldEntity);
            entities.Add(newEntity);
        }
    }
}