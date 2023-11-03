using enoca_NET_case.Models;

namespace enoca_NET_case.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();

        //add order
        Order AddOrder(Order order);

    }
}