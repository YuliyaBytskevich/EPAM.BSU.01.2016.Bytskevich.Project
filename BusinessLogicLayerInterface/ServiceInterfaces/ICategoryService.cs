using BusinessLogicLayerInterface.BLLModel;

namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface ICategoryService: IEntityService<BllCategory>
    {
        BllCategory GetCategoryByName(string name);

        void Create(string name);
    }
}
