using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayerInterface;
using DataAccessLayerInterface.DALModel;
using DataAccessLayerInterface.RepositoryInterfaces;
using EFModel;

namespace DataAccessLayer.SQLRepository
{
    public class SqlCategoryRepository: ICategoryRepository
    {
        private readonly DbContext db;

        public SqlCategoryRepository(DbContext context)
        {
            db = context;
        }

        public IEnumerable<DalCategory> GetAllEntities()
        {
            foreach (var category in db.Set<Category>()) yield return category.ToDalEntity();
        }

        public DalCategory GetEntityById(int id)
        {
            Category found = db.Set<Category>().SingleOrDefault(x => x.Id == id);
            return found?.ToDalEntity();
        }

        public DalCategory GetCategoryByName(string name)
        {
            Category found = db.Set<Category>().SingleOrDefault(x => x.Name == name);
            return found?.ToDalEntity();
        }

        public void Create(DalCategory newCategory)
        {
            db.Set<Category>().Add(newCategory.ToEfEntity());
        }

        public void Update(DalCategory categoryToBeUpdated)
        {
            Category entityFromDb = db.Set<Category>().SingleOrDefault(x => x.Id == categoryToBeUpdated.Id);
            if(entityFromDb == null) return;
            entityFromDb.Name = categoryToBeUpdated.Name;
            db.Entry(entityFromDb).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category toBeDeleted = db.Set<Category>().SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
                db.Set<Category>().Remove(toBeDeleted);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
