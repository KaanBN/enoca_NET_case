using enoca_NET_case.Data;
using enoca_NET_case.DTOs;
using enoca_NET_case.Exceptions;
using enoca_NET_case.Models;

namespace enoca_NET_case.Repositories
{
    public class CarrierRepository : ICarrierRepository
    {
        private readonly AppDbContext _context;

        public CarrierRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCarrier(CarrierDto carrierDto)
        {
            if (carrierDto.CarrierName == null)
            {
                throw new ValidationNotValidException("CarrierName zorunludur");
            }
            if (carrierDto.CarrierIsActive == null)
            {
                throw new ValidationNotValidException("CarrierIsActive zorunludur");
            }
            if (carrierDto.CarrierPlusDesiCost == null)
            {
                throw new ValidationNotValidException("CarrierPlusDesiCost zorunludur");
            }

            var carrier = new Carrier
            {
                CarrierName = (string)carrierDto.CarrierName,
                CarrierIsActive = (bool)carrierDto.CarrierIsActive,
                CarrierPlusDesiCost = (int)carrierDto.CarrierPlusDesiCost
            };
            _context.Carriers.Add(carrier);
            _context.SaveChanges();
        }

        public void DeleteCarrier(int id)
        {
            var carrier = _context.Carriers.Find(id);
            if (carrier == null)
            {
                throw new EntityNotFoundException(id);
            }

            _context.Carriers.Remove(carrier);
            _context.SaveChanges();
        }

        public List<Carrier> GetAllCarriers()
        {
            return _context.Carriers.ToList();
        }

        public void UpdateCarrier(int id,CarrierDto carrierDto)
        {
            var carrier = _context.Carriers.Find(id);
            if (carrier == null)
            {
                throw new EntityNotFoundException(carrierDto.CarrierId);
            }

            if (carrierDto.CarrierName != null)
                carrier.CarrierName = carrierDto.CarrierName;
            if (carrierDto.CarrierIsActive != null)
                carrier.CarrierIsActive = (bool)carrierDto.CarrierIsActive;
            if (carrierDto.CarrierPlusDesiCost != null)
                carrier.CarrierPlusDesiCost = (int)carrierDto.CarrierPlusDesiCost;
            _context.SaveChanges();
        }
    }
}
