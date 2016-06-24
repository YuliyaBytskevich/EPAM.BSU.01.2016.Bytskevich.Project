using System.Collections.Generic;
using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface IUserService: IEntityService<BllUser>
    {
        void Create(string login, string password, int roleId);

        IEnumerable<BllUser> GetUsersWithGivenParameters(string login = null, int roleId = -1);
    }
}
