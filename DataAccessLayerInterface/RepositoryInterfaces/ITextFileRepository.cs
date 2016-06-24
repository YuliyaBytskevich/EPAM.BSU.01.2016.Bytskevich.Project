using System.Collections.Generic;
using DataAccessLayerInterface.DALModel;

namespace DataAccessLayerInterface.RepositoryInterfaces
{
    public interface ITextFileRepository: IRepository<DalTextFile>
    {
        IEnumerable<DalTextFile> GetTextWithGivenParameters(DalTextFile sample);
    }
}
