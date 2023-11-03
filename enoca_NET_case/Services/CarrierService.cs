using enoca_NET_case.DTOs;
using enoca_NET_case.Models;
using enoca_NET_case.Repositories;

namespace enoca_NET_case.Services
{
    public class CarrierService : ICarrierService
    {
        private readonly ICarrierRepository _carrierRepository;

        public CarrierService(ICarrierRepository carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }

        public void CreateCarrier(CarrierDto carrierDto)
        {
            _carrierRepository.CreateCarrier(carrierDto);
        }

        public void DeleteCarrier(int id)
        {
            _carrierRepository.DeleteCarrier(id);
        }

        public List<Carrier> GetAllCarriers()
        {
            return _carrierRepository.GetAllCarriers();
        }

        public void UpdateCarrier(int id, CarrierDto carrierDto)
        {
            _carrierRepository.UpdateCarrier(id,carrierDto);
        }
    }
}
