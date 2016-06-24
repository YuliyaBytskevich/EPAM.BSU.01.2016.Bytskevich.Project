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
    public class SqlAudioGenreRepository : IAudioGenreRepository
    {
        private readonly DbContext db;

        public SqlAudioGenreRepository(DbContext context)
        {
            db = context;
        }

        public IEnumerable<DalAudioGenre> GetAllEntities()
        {
            foreach (var genre in db.Set<AudioGenre>()) yield return genre.ToDalEntity();
        }

        public DalAudioGenre GetEntityById(int id)
        {
            AudioGenre found = db.Set<AudioGenre>().SingleOrDefault(x => x.Id == id);
            return found?.ToDalEntity();
        }

        public DalAudioGenre GetGenreByName(string name)
        {
            AudioGenre found = db.Set<AudioGenre>().SingleOrDefault(x => x.Name == name);
            return found?.ToDalEntity();
        }

        public void Create(DalAudioGenre newGenre)
        {
            db.Set<AudioGenre>().Add(newGenre.ToEfEntity());
        }

        public void Update(DalAudioGenre genreToBeUpdated)
        {
            AudioGenre actualGenreInDb = db.Set<AudioGenre>().SingleOrDefault(x => x.Id == genreToBeUpdated.Id);
            if (actualGenreInDb == null) return;
            actualGenreInDb.Name = genreToBeUpdated.Name;
            db.Entry(actualGenreInDb).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AudioGenre toBeDeleted = db.Set<AudioGenre>().SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
                db.Set<AudioGenre>().Remove(toBeDeleted);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

    }
}

