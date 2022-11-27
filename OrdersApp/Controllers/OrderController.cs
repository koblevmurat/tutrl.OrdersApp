using Microsoft.AspNetCore.Mvc;
using OrdersApp.Interfaces;
using OrdersApp.Models;

namespace OrdersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetOrders() { 
            var orders = _orderRepository.GetOrders();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(orders);
        }

    }
}
