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
            var carrier = new Carrier
            {
                CarrierName = carrierDto.CarrierName,

            };
            _carrierRepository.CreateCarrier(carrier);
        }

        public List<Carrier> GetAllCarriers()
        {
            return _carrierRepository.GetAllCarriers();
        }
    }
}
