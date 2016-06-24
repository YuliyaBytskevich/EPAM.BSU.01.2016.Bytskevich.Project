using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayerInterface;
using BusinessLogicLayerInterface.BLLModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayer.Services
{
    public class AudioFileService: IAudioFileService
    {
        private readonly IAudioFileRepository audioRepository;

        public AudioFileService(IAudioFileRepository repository)
        {
            audioRepository = repository;
        }

        public IEnumerable<BllAudioFile> GetAllEntities()
        {
            return audioRepository.GetAllEntities().Select(dalEntity => dalEntity.ToBllEntity());
        }

        public BllAudioFile GetEntityById(int id)
        {
            return audioRepository.GetEntityById(id).ToBllEntity();
        }

        public IEnumerable<BllAudioFile> GetAudiosWithGivenParameters(string name = null, string author = null, int genreId = -1, int cardId = -1)
        {
            BllAudioFile sampleAudio = new BllAudioFile()
            {
                Name = name,
                Author = author,
                GenreId = genreId,
                CardId = cardId
            };
            var dalResult = audioRepository.GetAudioWithGivenParameters(sampleAudio.ToDalEntity());
            return dalResult?.Select(dalEntity => dalEntity.ToBllEntity());
        }

        public void Create(BllAudioFile entity)
        {
            audioRepository.Create(entity.ToDalEntity());
            audioRepository.SaveChanges();
        }

        public void Create(string name, string author, string path, int genreId, int cardId)
        {
            BllAudioFile newAudio = new BllAudioFile()
            {
                Name = name,
                Author = author,
                Path = path,
                GenreId = genreId,
                CardId = cardId
            };
            audioRepository.Create(newAudio.ToDalEntity());
            audioRepository.SaveChanges();
        }

        public void Update(BllAudioFile entity)
        {
            audioRepository.Update(entity.ToDalEntity());
            audioRepository.SaveChanges();
        }

        public void Delete(int entityId)
        {
            audioRepository.Delete(entityId);
            audioRepository.SaveChanges();
        }
    }
}
