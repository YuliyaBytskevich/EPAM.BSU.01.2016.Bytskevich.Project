using BusinessLogicLayerInterface.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayerInterface;
using BusinessLogicLayerInterface.BLLModel;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository repository)
        {
            roleRepository = repository;
        }

        public IEnumerable<BllRole> GetAllEntities()
        {
            return roleRepository.GetAllEntities().Select(dalEntity => dalEntity.ToBllEntity());
        }

        public BllRole GetEntityById(int id)
        {
            return roleRepository.GetEntityById(id).ToBllEntity();
        }

        public BllRole GetRoleByName(string name)
        {
            return roleRepository.GetRoleByName(name).ToBllEntity();
        }

        public void Create(BllRole entity)
        {
            roleRepository.Create(entity.ToDalEntity());
            roleRepository.SaveChanges();
        }

        public void Create(string name, string description)
        {
            BllRole newRole = new BllRole() {Name = name, Description = description};
            roleRepository.Create(newRole.ToDalEntity());
            roleRepository.SaveChanges();
        }

        public void Update(BllRole entity)
        {
            roleRepository.Update(entity.ToDalEntity());
            roleRepository.SaveChanges();
        }

        public void Delete(int entityId)
        {
            roleRepository.Delete(entityId);
            roleRepository.SaveChanges();
        }
        
    }
}
