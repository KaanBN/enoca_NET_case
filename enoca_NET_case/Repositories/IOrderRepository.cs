using enoca_NET_case.DTOs;
using enoca_NET_case.Models;

namespace enoca_NET_case.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();

        void AddOrder(OrderDto orderDto);

        void DeleteOrder(int id);

    }
}