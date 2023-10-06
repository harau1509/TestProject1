using Microsoft.AspNetCore.Mvc;
using SampleAPI.Entities;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;

        public OrdersController(IOrderRepository orderRepository, ILogger<OrdersController> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
 
        [HttpGet("GetRecentOrders")] // TODO: Change route, if needed.
        [ProducesResponseType(StatusCodes.Status200OK)] // TODO: Add all response types
        public async Task<ActionResult<List<Order>>> GetRecentOrders()
        {
            try
            {
                var result = await _orderRepository.GetRecentOrders();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost("AddNewOrder")]
        public async Task<IActionResult> AddNewOrder([FromBody] List<Order> orders)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _orderRepository.AddNewOrder(orders);
                    return Ok("Order created successfully");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return BadRequest("Something went wrong!");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpGet("GetAllOrders")]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            try
            {
                var result = await _orderRepository.GetAllOrders();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Something went wrong!");
            }
        }

        /// TODO: Add an endpoint to allow users to create an order using <see cref="CreateOrderRequest"/>.
    }
}
