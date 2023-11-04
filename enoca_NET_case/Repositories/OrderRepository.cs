using enoca_NET_case.Data;
using enoca_NET_case.DTOs;
using enoca_NET_case.Exceptions;
using enoca_NET_case.Models;

namespace enoca_NET_case.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddOrder(OrderDto orderDto)
        {
            if (orderDto.OrderDesi == null)
            {
                throw new ValidationNotValidException("OrderDesi zorunludur");
            }

            var availableCarrierConfs = _context.CarrierConfigurations.Where(x => x.Carrier.CarrierIsActive == true).ToList();

            if (availableCarrierConfs.Count == 0)
            {
                throw new ValidationNotValidException("Aktif kargo firması bulunamadı");
            }

            var carrierConfs = availableCarrierConfs.Where(x => x.CarrierMinDesi <= (int)orderDto.OrderDesi && x.CarrierMaxDesi >= (int)orderDto.OrderDesi).ToList();

            Order order = new Order();

            if (carrierConfs.Count != 0)
            {
                var lowestCost = carrierConfs.OrderBy(x => x.CarrierCost).First();
                var carrier2 = _context.Carriers.Find(lowestCost.CarrierId);
                order = new Order
                {
                    CarrierId = lowestCost.CarrierId,
                    OrderDesi = (int)orderDto.OrderDesi,
                    OrderDate = DateTime.Now,
                    OrderCarrierCost = lowestCost.CarrierCost
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                return;
            }

            var closestCarrier = _context.CarrierConfigurations.OrderBy(x => Math.Abs(x.CarrierMinDesi - (int)orderDto.OrderDesi)).First();


            var carrier = _context.Carriers.Find(closestCarrier.CarrierId);
            var carrierPlusDesiCost = carrier.CarrierPlusDesiCost;

            var desiDifference = Math.Min(Math.Abs(closestCarrier.CarrierMinDesi - (int)orderDto.OrderDesi), Math.Abs(closestCarrier.CarrierMaxDesi - (int)orderDto.OrderDesi));

            var orderCarrierCost = closestCarrier.CarrierCost + (desiDifference * carrierPlusDesiCost);


            order = new Order
            {
                CarrierId = closestCarrier.CarrierId,
                OrderDesi = (int)orderDto.OrderDesi,
                OrderDate = DateTime.Now,
                OrderCarrierCost = (decimal)orderCarrierCost
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return;

        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                throw new EntityNotFoundException(id);
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        List<Order> IOrderRepository.GetAllOrders()
        {
            return _context.Orders.ToList();
        }
    }
}
