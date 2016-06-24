using System.Collections.Generic;
using DataAccessLayerInterface.DALModel;

namespace DataAccessLayerInterface.RepositoryInterfaces
{
    public interface IAudioFileRepository: IRepository<DalAudioFile>
    {
        IEnumerable<DalAudioFile> GetAudioWithGivenParameters(DalAudioFile sample);
    }
}
