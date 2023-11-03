using enoca_NET_case.DTOs;
using enoca_NET_case.Models;
using enoca_NET_case.Repositories;

namespace enoca_NET_case.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                CarrierId = orderDto.CarrierId,
                OrderDesi = orderDto.OrderDesi,
                OrderDate = orderDto.OrderDate,
                OrderCarrierCost = orderDto.OrderCarrierCost
            };

            _orderRepository.AddOrder(order);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }
    }
}