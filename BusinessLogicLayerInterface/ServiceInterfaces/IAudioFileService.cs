using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface IAudioFileService: IEntityService<BllAudioFile>
    {
        IEnumerable<BllAudioFile> GetAudiosWithGivenParameters(string name = null,
                                                               string author = null,
                                                               int genreId = -1,
                                                               int cardId = -1);

        void Create(string name, string author, string path, int genreId, int cardId);
    }
}
