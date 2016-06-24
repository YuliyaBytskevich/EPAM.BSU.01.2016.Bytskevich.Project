using System.Collections.Generic;
using DataAccessLayerInterface.DALModel;

namespace DataAccessLayerInterface.RepositoryInterfaces
{
    public interface IUserRepository: IRepository<DalUser>
    {
        IEnumerable<DalUser> GetUserWithGivenParameters(DalUser sample);
    }
}
