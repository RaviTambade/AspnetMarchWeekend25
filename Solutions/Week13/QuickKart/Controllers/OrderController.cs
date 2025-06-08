using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickKart.Commands;
using QuickKart.Queries;
using QuickKart.Domain.Entities;

namespace QuickKart.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand command) {
            var id = await _mediator.Send(command);
            return Ok(new { OrderId = id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id) {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
