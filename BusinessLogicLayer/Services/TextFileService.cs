using BusinessLogicLayerInterface.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayerInterface;
using BusinessLogicLayerInterface.BLLModel;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayer.Services
{
    public class TextFileService: ITextFileService
    {
        private readonly ITextFileRepository textRepository;

        public TextFileService(ITextFileRepository repository)
        {
            textRepository = repository;
        }

        public IEnumerable<BllTextFile> GetAllEntities()
        {
            return textRepository.GetAllEntities().Select(dalEntity => dalEntity.ToBllEntity());
        }

        public BllTextFile GetEntityById(int id)
        {
            return textRepository.GetEntityById(id).ToBllEntity();
        }

        public IEnumerable<BllTextFile> GetTextsWithGivenParameters(string name = null, string author = null, int cardId = -1)
        {
            BllTextFile sampleText = new BllTextFile()
            {
                Name = name,
                Author = author,
                CardId = cardId
            };
            var dalResult = textRepository.GetTextWithGivenParameters(sampleText.ToDalEntity());
            return dalResult?.Select(dalEntity => dalEntity.ToBllEntity());
        }

        public void Create(BllTextFile entity)
        {
            textRepository.Create(entity.ToDalEntity());
            textRepository.SaveChanges();
        }

        public void Create(string name, string author, string path, int cardId)
        {
            BllTextFile newText = new BllTextFile()
            {
                Name = name,
                Author = author,
                Path = path,
                CardId = cardId
            };
            textRepository.Create(newText.ToDalEntity());
            textRepository.SaveChanges();
        }

        public void Update(BllTextFile entity)
        {
            textRepository.Update(entity.ToDalEntity());
            textRepository.SaveChanges();
        }

        public void Delete(int entityId)
        {
            textRepository.Delete(entityId);
            textRepository.SaveChanges();
        }
    }
}
