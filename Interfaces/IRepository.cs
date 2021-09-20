using System.Collections.Generic;

namespace MySeries.Interfaces {
    public interface IRepository<T> {
         List<T> List();
         T GetID(int id);
         void Insert(T entity);
         void Delete(int id);
         void Update(int id, T entity);
         int NextId();
    }
}