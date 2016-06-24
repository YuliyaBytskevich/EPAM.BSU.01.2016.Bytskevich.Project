using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayerInterface;
using DataAccessLayerInterface.DALModel;
using DataAccessLayerInterface.RepositoryInterfaces;
using EFModel;

namespace DataAccessLayer.SQLRepository
{
    public class SqlRoleRepository: IRoleRepository
    {
        private readonly DbContext db;

        public SqlRoleRepository(DbContext context)
        {
            db = context;
        }

        public IEnumerable<DalRole> GetAllEntities()
        {
            foreach (var role in db.Set<Role>()) yield return role.ToDalEntity();
        }

        public DalRole GetEntityById(int id)
        {
            Role found = db.Set<Role>().SingleOrDefault(x => x.Id == id);
            return found?.ToDalEntity();
        }

        public DalRole GetRoleByName(string name)
        {
            Role found = db.Set<Role>().SingleOrDefault(x => x.Name == name);
            return found?.ToDalEntity();
        }

        public void Create(DalRole newRole)
        {
            db.Set<Role>().Add(newRole.ToEfEntiity());
        }

        public void Update(DalRole roleToBeUpdated)
        {
            Role efRoleEntity = db.Set<Role>().SingleOrDefault(x => x.Id == roleToBeUpdated.Id);
            if (efRoleEntity == null) return;
            efRoleEntity.Name = roleToBeUpdated.Name;
            efRoleEntity.Description = roleToBeUpdated.Description;
            db.Entry(efRoleEntity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Role toBeDeleted = db.Set<Role>().SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
                db.Set<Role>().Remove(toBeDeleted);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

    }
}



