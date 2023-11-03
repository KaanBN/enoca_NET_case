using enoca_NET_case.Models;

namespace enoca_NET_case.Repositories
{
    public interface ICarrierRepository
    {
        List<Carrier> GetAllCarriers();

        void CreateCarrier(Carrier carrier);
    }
}
