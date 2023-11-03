using enoca_NET_case.DTOs;
using enoca_NET_case.Models;

namespace enoca_NET_case.Services
{
    public interface ICarrierService
    {
        List<Carrier> GetAllCarriers();

        void CreateCarrier(CarrierDto carrierDto);

        void UpdateCarrier(int id,CarrierDto carrierDto);

        void DeleteCarrier(int id);
    }
}
