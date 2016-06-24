using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayerInterface;
using DataAccessLayerInterface.DALModel;
using DataAccessLayerInterface.RepositoryInterfaces;
using EFModel;

namespace DataAccessLayer.SQLRepository
{
    public class SqlTextFileRepository: ITextFileRepository
    {
        private readonly DbContext db;

        public SqlTextFileRepository(DbContext context)
        {
            db = context;
        }

        public IEnumerable<DalTextFile> GetAllEntities()
        {
            foreach (var text in db.Set<TextFile>()) yield return text.ToDalEntity();
        }

        public DalTextFile GetEntityById(int id)
        {
            TextFile found = db.Set<TextFile>().SingleOrDefault(x => x.Id == id);
            return found?.ToDalEntity();
        }

        public IEnumerable<DalTextFile> GetTextWithGivenParameters(DalTextFile sampleText)
        {
            IQueryable<TextFile> query = db.Set<TextFile>()
                .Where(c =>
                    (sampleText.Name == null || c.Name.Contains(sampleText.Name)) &&
                    (sampleText.Author == null || c.Author.Contains(sampleText.Author)) &&
                    (sampleText.CardId < 0 || c.CardId == sampleText.CardId));
            foreach (var text in query) yield return text.ToDalEntity();
        }

        public void Create(DalTextFile newText)
        {
            TextFile entityForDb = newText.ToEfEntity();
            db.Set<TextFile>().Add(entityForDb);
        }
        public void Update(DalTextFile textToBeUpdated)
        {
            TextFile entityFromDb = db.Set<TextFile>().SingleOrDefault(x => x.Id == textToBeUpdated.Id);
            if (entityFromDb == null) return;
            entityFromDb.Name = textToBeUpdated.Name;
            entityFromDb.Author = textToBeUpdated.Author;
            entityFromDb.Path = textToBeUpdated.Path;
            entityFromDb.CardId = textToBeUpdated.CardId;
            db.Entry(entityFromDb).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TextFile toBeDeleted = db.Set<TextFile>().SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
                db.Set<TextFile>().Remove(toBeDeleted);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
