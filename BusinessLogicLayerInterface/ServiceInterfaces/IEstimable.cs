namespace BusinessLogicLayerInterface.ServiceInterfaces
{
    public interface IEstimable
    {
        void EstimatePositively(int id);

        void EstimateNegatively(int id);
    }
}
