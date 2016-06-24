using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayerInterface;
using BusinessLogicLayerInterface.BLLModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayer.Services
{
    public class AudioGenreService: IAudioGenreService
    {
        private readonly IAudioGenreRepository genreRepository;

        public AudioGenreService(IAudioGenreRepository repository)
        {
            genreRepository = repository;
        }
        public IEnumerable<BllAudioGenre> GetAllEntities()
        {
            return genreRepository.GetAllEntities().Select(dalEntity => dalEntity.ToBllEntity());
        }

        public BllAudioGenre GetEntityById(int id)
        {
            return genreRepository.GetEntityById(id).ToBllEntity();
        }

        public BllAudioGenre GetGenreByName(string name)
        {
            return genreRepository.GetGenreByName(name).ToBllEntity();
        }

        public void Create(BllAudioGenre entity)
        {
            genreRepository.Create(entity.ToDalEntity());
            genreRepository.SaveChanges();
        }

        public void Create(string name)
        {
            BllAudioGenre newGenre = new BllAudioGenre() { Name = name };
            genreRepository.Create(newGenre.ToDalEntity());
            genreRepository.SaveChanges();
        }

        public void Update(BllAudioGenre entity)
        {
            genreRepository.Update(entity.ToDalEntity());
            genreRepository.SaveChanges();
        }

        public void Delete(int entityId)
        {
            genreRepository.Delete(entityId);
            genreRepository.SaveChanges();
        }
    }
}
