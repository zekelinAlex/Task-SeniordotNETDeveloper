using Microsoft.AspNetCore.Mvc;
using Task_SeniordotNETDeveloper.Models;
using Task_SeniordotNETDeveloper.Services.Interfaces;

namespace Task_SeniordotNETDeveloper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            ArgumentNullException.ThrowIfNull(orderService, nameof(orderService));

            _orderService = orderService;
        }

        [HttpPost]
        [Route("order")]
        public IActionResult MakeNewOrder([FromBody] OrderModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            _orderService.AddOrder(order);

            //Je také nutné implementovat middleware pro kontrolu chyb.

            return Ok();
        }
    }
}
