using AdemShop.Order.Application.Features.Mediator.Commands.OrderingCommand;
using AdemShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdemShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{orderingId}")]
        public async Task<IActionResult> GetOrdering(Guid id) 
        {
            var data = await _mediator.Send(new GetOrderingQuery(id));
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var data = await _mediator.Send(new GetAlllOrderingQuery());
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createCommand)
        {
            await _mediator.Send(createCommand);
            return Ok("Sipariş başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(Guid id)
        {
            await _mediator.Send(new DeleteOrderingCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateCommand)
        {
            await _mediator.Send(updateCommand);
            return Ok("Sipariş başarıyla güncellendi");
        }
    }
}
