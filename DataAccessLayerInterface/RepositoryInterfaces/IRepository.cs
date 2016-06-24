using System.Collections.Generic;

namespace DataAccessLayerInterface
{
    public interface IRepository<T> where T : DalEntity
    {
        IEnumerable<T> GetAllEntities(); 
        T GetEntityById(int id);
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void SaveChanges();  
    }

}
