using enoca_NET_case.Data;
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
        public List<Carrier> GetAllCarriers()
        {
            return _context.Carriers.ToList();
        }

        void ICarrierRepository.CreateCarrier(Carrier carrier)
        {
            _context.Carriers.Add(carrier);
            _context.SaveChanges();
        }
    }
}
