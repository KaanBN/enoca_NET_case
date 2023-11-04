using enoca_NET_case.Data;
using enoca_NET_case.DTOs;
using enoca_NET_case.Exceptions;
using enoca_NET_case.Models;

namespace enoca_NET_case.Repositories
{
    public class CarrierConfigurationRepository : ICarrierConfigurationRepository
    {
        private readonly AppDbContext _context;

        public CarrierConfigurationRepository(AppDbContext context) {
            _context = context;
        }

        public void CreateCarrierConfiguration(CarrierConfigurationDto carrierConfigurationDto)
        {
            if (carrierConfigurationDto.CarrierId == null)
            {
                throw new ValidationNotValidException("CarrierId zorunludur!");
            }

            var carrier = _context.Carriers.Find(carrierConfigurationDto.CarrierId);
            if (carrier == null)
            {
                throw new EntityNotFoundException((int)carrierConfigurationDto.CarrierId);
            }

            if (carrierConfigurationDto.CarrierMaxDesi == null)
            {
                throw new ValidationNotValidException("CarrierMaxDesi zorunludur!");
            }

            if (carrierConfigurationDto.CarrierMinDesi > carrierConfigurationDto.CarrierMaxDesi)
            {
                throw new ValidationNotValidException("CarrierMinDesi CarrierMaxDesi'den büyük olamaz!");
            }

            if (carrierConfigurationDto.CarrierMinDesi == null)
            {
                throw new ValidationNotValidException("CarrierMinDesi zorunludur!");
            }

            if (carrierConfigurationDto.CarrierCost == null)
            {
                throw new ValidationNotValidException("CarrierCost zorunludur!");
            }

            var carrierConfiguration = new CarrierConfiguration
            {
                CarrierId = (int)carrierConfigurationDto.CarrierId,
                CarrierMaxDesi = (int)carrierConfigurationDto.CarrierMaxDesi,
                CarrierMinDesi = (int)carrierConfigurationDto.CarrierMinDesi,
                CarrierCost = (decimal)carrierConfigurationDto.CarrierCost,
                Carrier = carrier
            };

            _context.CarrierConfigurations.Add(carrierConfiguration);
            _context.SaveChanges();
        }

        public void DeleteCarrierConfiguration(int id)
        {
            var carrierConfiguration = _context.CarrierConfigurations.Find(id);
            if (carrierConfiguration == null)
            {
                throw new EntityNotFoundException(id);
            }
            _context.CarrierConfigurations.Remove(carrierConfiguration);
            _context.SaveChanges();
        }

        public List<CarrierConfiguration> GetAllCarrierConfigurations()
        {
            return _context.CarrierConfigurations.ToList();
        }

        public void UpdateCarrierConfiguration(int id, CarrierConfigurationDto carrierConfigurationDto)
        {
            var carrierConfiguration = _context.CarrierConfigurations.Find(id);
            if (carrierConfiguration == null)
            {
                throw new EntityNotFoundException(id);
            }
            if (carrierConfigurationDto.CarrierId == null)
            {
                throw new ValidationNotValidException("CarrierId zorunludur!");
            }
            var carrier = _context.Carriers.Find(carrierConfigurationDto.CarrierId);
            if (carrier == null)
            {
                throw new EntityNotFoundException((int)carrierConfigurationDto.CarrierId);
            }
            if (carrierConfigurationDto.CarrierMaxDesi != null)
            {
                if (carrierConfigurationDto.CarrierMinDesi > carrierConfigurationDto.CarrierMaxDesi)
                {
                    throw new ValidationNotValidException("CarrierMinDesi CarrierMaxDesi'den büyük olamaz!");
                }
                carrierConfiguration.CarrierMaxDesi = (int)carrierConfigurationDto.CarrierMaxDesi;
            }
            if (carrierConfigurationDto.CarrierMinDesi != null)
            {
                if (carrierConfigurationDto.CarrierMinDesi > carrierConfigurationDto.CarrierMaxDesi)
                {
                    throw new ValidationNotValidException("CarrierMinDesi CarrierMaxDesi'den büyük olamaz!");
                }
                carrierConfiguration.CarrierMinDesi = (int)carrierConfigurationDto.CarrierMinDesi;
            }
            if (carrierConfigurationDto.CarrierCost != null)
            {
                carrierConfiguration.CarrierCost = (decimal)carrierConfigurationDto.CarrierCost;
            }


            carrierConfiguration.CarrierId = (int)carrierConfigurationDto.CarrierId;
            carrierConfiguration.Carrier = carrier;

            _context.CarrierConfigurations.Update(carrierConfiguration);
            _context.SaveChanges(); 
        }
    }
}
