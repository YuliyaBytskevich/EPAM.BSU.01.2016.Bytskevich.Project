using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterface.DALModel;

namespace DataAccessLayerInterface.RepositoryInterfaces
{
    public interface ICategoryRepository : IRepository<DalCategory>
    {
        DalCategory GetCategoryByName(string name);
    }
}
