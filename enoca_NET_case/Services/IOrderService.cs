using enoca_NET_case.DTOs;
using enoca_NET_case.Models;

namespace enoca_NET_case.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();

        void AddOrder(OrderDto orderDto);

        void DeleteOrder(int id);
    }
}
