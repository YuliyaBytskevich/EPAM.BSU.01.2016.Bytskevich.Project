using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayerInterface;
using BusinessLogicLayerInterface.BLLModel;
using BusinessLogicLayerInterface.ServiceInterfaces;
using DataAccessLayerInterface.RepositoryInterfaces;

namespace BusinessLogicLayer.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }
        public IEnumerable<BllUser> GetAllEntities()
        {
            return userRepository.GetAllEntities().Select(dalEntity => dalEntity.ToBllEntity());
        }

        public BllUser GetEntityById(int id)
        {
            return userRepository.GetEntityById(id).ToBllEntity();
        }

        public IEnumerable<BllUser> GetUsersWithGivenParameters(string login = null, int roleId = -1)
        {
            BllUser sampleUser = new BllUser()
            {
                Login = login,
                RoleId = roleId
            };
            var dalResult = userRepository.GetUserWithGivenParameters(sampleUser.ToDalEntity());
            return dalResult?.Select(dalEntity => dalEntity.ToBllEntity());
        }

        public void Create(BllUser entity)
        {
            userRepository.Create(entity.ToDalEntity());
            userRepository.SaveChanges();
        }

        public void Create(string login, string password, int roleId)
        {
            BllUser newUser = new BllUser()
            {
                Login = login,
                Password = password,
                RoleId = roleId
            };
            userRepository.Create(newUser.ToDalEntity());
            userRepository.SaveChanges();
        }

        public void Update(BllUser entity)
        {
            userRepository.Update(entity.ToDalEntity());
            userRepository.SaveChanges();
        }

        public void Delete(int entityId)
        {
            userRepository.Delete(entityId);
            userRepository.SaveChanges();
        }
    }
}
