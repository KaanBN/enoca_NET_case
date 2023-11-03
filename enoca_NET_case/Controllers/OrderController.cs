using enoca_NET_case.DTOs;
using enoca_NET_case.Exceptions;
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
        public IActionResult AddOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                _orderService.AddOrder(orderDto);
                return Ok("Order başarıyla oluşturuldu!");
            }
            catch (ValidationNotValidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return Ok("Order silindi");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
