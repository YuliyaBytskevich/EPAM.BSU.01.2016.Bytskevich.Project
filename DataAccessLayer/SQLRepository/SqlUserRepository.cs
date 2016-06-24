using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterface;
using DataAccessLayerInterface.DALModel;
using DataAccessLayerInterface.RepositoryInterfaces;
using EFModel;

namespace DataAccessLayer.SQLRepository
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly DbContext db;

        public SqlUserRepository(DbContext context)
        {
            db = context;
        }

        public IEnumerable<DalUser> GetAllEntities()
        {
            foreach (var user in db.Set<User>()) yield return user.ToDalEntity();
        }

        public DalUser GetEntityById(int id)
        {
            User found = db.Set<User>().SingleOrDefault(x => x.Id == id);
            return found?.ToDalEntity();
        }

        public IEnumerable<DalUser> GetUserWithGivenParameters(DalUser sampleUser)
        {
            IQueryable<User> query = db.Set<User>()
                .Where(c =>
                    (sampleUser.Login == null || c.Login == sampleUser.Login) &&
                    (sampleUser.Password == null || c.Password == sampleUser.Password) &&
                    (sampleUser.RoleId < 0 || c.RoleId == sampleUser.RoleId));
            foreach (var user in query) yield return user.ToDalEntity();
        }

        public void Create(DalUser newUser)
        {
            User entityForDb = newUser.ToEfEntity();
            db.Set<User>().Add(entityForDb);
        }
        public void Update(DalUser userToBeUpdated)
        {
            User entityFromDb = db.Set<User>().SingleOrDefault(x => x.Id == userToBeUpdated.Id);
            if(entityFromDb == null) return;
            entityFromDb.Login = userToBeUpdated.Login;
            entityFromDb.Password = userToBeUpdated.Password;
            entityFromDb.RoleId = userToBeUpdated.RoleId;
            db.Entry(entityFromDb).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User toBeDeleted = db.Set<User>().SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
                db.Set<User>().Remove(toBeDeleted);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
        
    }
}
