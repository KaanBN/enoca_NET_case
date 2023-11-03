using enoca_NET_case.DTOs;
using enoca_NET_case.Models;

namespace enoca_NET_case.Repositories
{
    public interface ICarrierConfigurationRepository
    {
        List<CarrierConfiguration> GetAllCarrierConfigurations();

        void CreateCarrierConfiguration(CarrierConfigurationDto carrierConfigurationDto);

        void UpdateCarrierConfiguration(int id,CarrierConfigurationDto carrierConfigurationDto);

        void DeleteCarrierConfiguration(int id);
    }
}
