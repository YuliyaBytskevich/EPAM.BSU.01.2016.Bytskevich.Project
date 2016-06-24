using System.Collections.Generic;
using DataAccessLayerInterface.DALModel;

namespace DataAccessLayerInterface.RepositoryInterfaces
{
    public interface IImageRepository: IRepository<DalImage>
    {
        IEnumerable<DalImage> GetImageWithGivenParameters(DalImage sample);
    }
}
