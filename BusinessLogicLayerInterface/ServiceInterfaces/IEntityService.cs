using System.Collections.Generic;
using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface IEntityService<T> where T:BllEntity
    {
        IEnumerable<T> GetAllEntities();
        T GetEntityById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int entityId);
    }
}
