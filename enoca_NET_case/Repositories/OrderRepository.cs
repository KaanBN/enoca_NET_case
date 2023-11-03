using enoca_NET_case.Data;
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

        List<Order> IOrderRepository.GetAllOrders()
        {
            return _context.Orders.ToList();
        }
    }
}
