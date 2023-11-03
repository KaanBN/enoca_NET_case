using enoca_NET_case.DTOs;
using enoca_NET_case.Models;
using enoca_NET_case.Services;
using Microsoft.AspNetCore.Mvc;

namespace enoca_NET_case.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderDto orderDto) // [FromBody] OrderDto orderDto
        {
            _orderService.AddOrder(orderDto);
            return Ok(orderDto);
        }

    }
}
