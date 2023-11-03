using enoca_NET_case.DTOs;
using enoca_NET_case.Models;
using enoca_NET_case.Repositories;

namespace enoca_NET_case.Services
{
    public class CarrierConfigurationService: ICarrierConfigurationService
    {
        private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;

        public CarrierConfigurationService(ICarrierConfigurationRepository carrierConfigurationRepository)
        {
            _carrierConfigurationRepository = carrierConfigurationRepository;
        }

        public void CreateCarrierConfiguration(CarrierConfigurationDto carrierConfigurationDto)
        {
            _carrierConfigurationRepository.CreateCarrierConfiguration(carrierConfigurationDto);
        }

        public void DeleteCarrierConfiguration(int id)
        {
            _carrierConfigurationRepository.DeleteCarrierConfiguration(id);
        }

        public List<CarrierConfiguration> GetAllCarrierConfigurations()
        {
            return _carrierConfigurationRepository.GetAllCarrierConfigurations();
        }

        public void UpdateCarrierConfiguration(int id, CarrierConfigurationDto carrierConfigurationDto)
        {
            _carrierConfigurationRepository.UpdateCarrierConfiguration(id, carrierConfigurationDto);
        }
    }
}
