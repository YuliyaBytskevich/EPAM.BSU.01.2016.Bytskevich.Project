using DataAccessLayerInterface.DALModel;

namespace DataAccessLayerInterface.RepositoryInterfaces
{
    public interface IRoleRepository: IRepository<DalRole>
    {
        DalRole GetRoleByName(string name);
    }
}
