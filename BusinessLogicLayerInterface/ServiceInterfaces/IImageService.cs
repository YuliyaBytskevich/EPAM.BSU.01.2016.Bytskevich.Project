using System.Collections.Generic;
using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface IImageService: IEntityService<BllImage>
    {
        IEnumerable<BllImage> GetImagesWithGivenParameters(string name = null, int cardId = -1);

        void Create(string name, string path, int cardId);
    }
}
