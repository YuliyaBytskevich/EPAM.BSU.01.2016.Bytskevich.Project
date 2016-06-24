using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface IAudioGenreService: IEntityService<BllAudioGenre>
    {
        BllAudioGenre GetGenreByName(string name);

        void Create(string name);
    }
}
