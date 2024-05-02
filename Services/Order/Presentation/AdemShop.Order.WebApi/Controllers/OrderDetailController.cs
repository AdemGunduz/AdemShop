using AdemShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using AdemShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using AdemShop.Order.Application.Features.CQRS.Handlers.AddressHandler;
using AdemShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;
using AdemShop.Order.Application.Features.CQRS.Queries.AddressQuery;
using AdemShop.Order.Application.Features.CQRS.Queries.OrderDetailQuery;
using AdemShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using AdemShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdemShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("orderDetailId}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var data = await _mediator.Send(new GetOrderDetailQuery(id));
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> DetailList()
        {
            var data = await _mediator.Send(new GetAlllOrderingQuery());
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createCommand)
        {
            await _mediator.Send(createCommand);
            return Ok("Sipariş detay başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            await _mediator.Send(new DeleteOrderDetailCommand(id));
            return Ok("Sipariş detay başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailCommand updateCommand)
        {
            await _mediator.Send(updateCommand);
            return Ok("Sipariş detay başarıyla güncellendi");
        }
    }
}
