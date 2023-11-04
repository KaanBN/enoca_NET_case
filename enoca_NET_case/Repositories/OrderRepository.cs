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

            var carrierConfs = _context.CarrierConfigurations.Where(x => x.Carrier.CarrierIsActive == true).ToList();

            Order order = new Order();

            foreach (var carrierConf in carrierConfs)
            {
                if (orderDto.OrderDesi >= carrierConf.CarrierMinDesi && orderDto.OrderDesi <= carrierConf.CarrierMaxDesi)
                {
                    var lowestCost = _context.CarrierConfigurations.OrderBy(x => x.Carrier.CarrierPlusDesiCost).First();
                    var carrier2 = _context.Carriers.Find(lowestCost.CarrierId);
                    order = new Order
                    {
                        CarrierId = lowestCost.CarrierId,
                        OrderDesi = (int)orderDto.OrderDesi,
                        OrderDate = DateTime.Now,
                        OrderCarrierCost = (int)orderDto.OrderDesi * carrier2.CarrierPlusDesiCost
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    return;
                }
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
