using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayerInterface;
using BusinessLogicLayerInterface.BLLModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayer.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }

        public IEnumerable<BllCategory> GetAllEntities()
        {
            return categoryRepository.GetAllEntities().Select(dalEntity => dalEntity.ToBllEntity());
        }

        public BllCategory GetEntityById(int id)
        {
            return categoryRepository.GetEntityById(id).ToBllEntity();
        }

        public BllCategory GetCategoryByName(string name)
        {
            return categoryRepository.GetCategoryByName(name).ToBllEntity();
        }

        public void Create(BllCategory entity)
        {
            categoryRepository.Create(entity.ToDalEntity());
            categoryRepository.SaveChanges();
        }

        public void Create(string name)
        {
            BllCategory newCategory = new BllCategory() { Name = name };
            categoryRepository.Create(newCategory.ToDalEntity());
            categoryRepository.SaveChanges();
        }

        public void Update(BllCategory entity)
        {
            categoryRepository.Update(entity.ToDalEntity());
            categoryRepository.SaveChanges();
        }

        public void Delete(int entityId)
        {
            categoryRepository.Delete(entityId);
            categoryRepository.SaveChanges();
        }
    }
}
