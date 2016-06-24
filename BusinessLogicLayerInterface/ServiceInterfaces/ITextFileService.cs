using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface ITextFileService: IEntityService<BllTextFile>
    {
        IEnumerable<BllTextFile> GetTextsWithGivenParameters(string name = null,
                                                             string author = null,
                                                             int cardId = -1);

        void Create(string name, string author, string path, int cardId);
    }
}
