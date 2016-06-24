using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayerInterface;
using DataAccessLayerInterface.DALModel;
using DataAccessLayerInterface.RepositoryInterfaces;
using EFModel;

namespace DataAccessLayer.SQLRepository
{
    public class SqlImageRepository: IImageRepository
    {
        private readonly DbContext db;

        public SqlImageRepository(DbContext context)
        {
            db = context;
        }

        public IEnumerable<DalImage> GetAllEntities()
        {
            foreach (var image in db.Set<Image>()) yield return image.ToDalEntity();
        }

        public DalImage GetEntityById(int id)
        {
            Image found = db.Set<Image>().SingleOrDefault(x => x.Id == id);
            return found?.ToDalEntity();
        }

        public IEnumerable<DalImage> GetImageWithGivenParameters(DalImage sampleImage)
        {
            IQueryable<Image> query = db.Set<Image>()
                .Where(c =>
                    (sampleImage.Name == null || c.Name.Contains(sampleImage.Name)) &&
                    (sampleImage.CardId < 0 || c.CardId == sampleImage.CardId));
            foreach (var image in query) yield return image.ToDalEntity();
        }

        public void Create(DalImage newImage)
        {
            db.Set<Image>().Add(newImage.ToEfEntity());
        }

        public void Update(DalImage imageToBeUpdated)
        {
            Image efImageEntity = db.Set<Image>().SingleOrDefault(x => x.Id == imageToBeUpdated.Id);
            if (efImageEntity == null) return;
            efImageEntity.Name = imageToBeUpdated.Name;
            efImageEntity.Path = imageToBeUpdated.Path;
            efImageEntity.CardId = imageToBeUpdated.CardId;
            db.Entry(efImageEntity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Image toBeDeleted = db.Set<Image>().SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
                db.Set<Image>().Remove(toBeDeleted);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
