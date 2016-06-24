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
    public class SqlAudioFileRepository: IAudioFileRepository
    {
        private readonly DbContext db;

        public SqlAudioFileRepository(DbContext context)
        {
            db = context;
        }

        public IEnumerable<DalAudioFile> GetAllEntities()
        {
            foreach (var audio in db.Set<AudioFile>()) yield return audio.ToDalEntity();
        }

        public DalAudioFile GetEntityById(int id)
        {
            AudioFile found = db.Set<AudioFile>().SingleOrDefault(x => x.Id == id);
            return found?.ToDalEntity();
        }

        public IEnumerable<DalAudioFile> GetAudioWithGivenParameters(DalAudioFile sampleAudio)
        {
            IQueryable<AudioFile> query = db.Set<AudioFile>()
                .Where(c =>
                    (sampleAudio.Name == null || c.Name.Contains(sampleAudio.Name)) &&
                    (sampleAudio.Author == null || c.Author.Contains(sampleAudio.Author)) &&
                    (sampleAudio.CardId < 0 || c.CardId == sampleAudio.CardId) &&
                    (sampleAudio.GenreId < 0 || c.GenreId == sampleAudio.GenreId));
            foreach (var audio in query) yield return audio.ToDalEntity();
        }

        public void Create(DalAudioFile newAudio)
        {
            db.Set<AudioFile>().Add(newAudio.ToEfEntity());
        }

        public void Update(DalAudioFile audioToBeUpdated)
        {
            AudioFile entityFromDb = db.Set<AudioFile>().SingleOrDefault(x => x.Id == audioToBeUpdated.Id);
            if (entityFromDb == null) return;
            entityFromDb.Name = audioToBeUpdated.Name;
            entityFromDb.Author = audioToBeUpdated.Author;
            entityFromDb.Path = audioToBeUpdated.Path;
            entityFromDb.CardId = audioToBeUpdated.CardId;
            entityFromDb.GenreId = audioToBeUpdated.GenreId;
            db.Entry(entityFromDb).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AudioFile toBeDeleted = db.Set<AudioFile>().SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
                db.Set<AudioFile>().Remove(toBeDeleted);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
