using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayerInterface;
using BusinessLogicLayerInterface.BLLModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayer.Services
{
    public class ImageService: IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository repository)
        {
            imageRepository = repository;
        }

        public IEnumerable<BllImage> GetAllEntities()
        {
            return imageRepository.GetAllEntities().Select(dalEntity => dalEntity.ToBllEntity());
        }

        public BllImage GetEntityById(int id)
        {
            return imageRepository.GetEntityById(id).ToBllEntity();
        }

        public IEnumerable<BllImage> GetImagesWithGivenParameters(string name = null, int cardId = -1)
        {
            BllImage sampleImage = new BllImage()
            {
                Name = name,
                CardId = cardId
            };
            return imageRepository.GetImageWithGivenParameters(sampleImage.ToDalEntity())
                                  .Select(dalEntity => dalEntity.ToBllEntity());
        }

        public void Create(BllImage entity)
        {
            imageRepository.Create(entity.ToDalEntity());
            imageRepository.SaveChanges();
        }

        public void Create(string name, string path, int cardId)
        {
            BllImage newImage = new BllImage()
            {
                Name = name,
                Path = path,
                CardId = cardId
            };
            imageRepository.Create(newImage.ToDalEntity());
            imageRepository.SaveChanges();
        }

        public void Update(BllImage entity)
        {
            imageRepository.Update(entity.ToDalEntity());
            imageRepository.SaveChanges();
        }

        public void Delete(int entityId)
        {
            imageRepository.Delete(entityId);
            imageRepository.SaveChanges();
        }
    }
}
