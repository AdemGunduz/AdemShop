using AdemShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using AdemShop.Order.Application.Features.CQRS.Queries.AddressQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdemShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            var data = await _mediator.Send(new GetAddressQuery(id));
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var data = await _mediator.Send(new GetAllAddressQuery());
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createCommand)
        {
            await _mediator.Send(createCommand);
            return Ok("Adres bilgisi başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            await _mediator.Send(new DeleteAddressCommand(id));
            return Ok("Adres bilgisi başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateCommand)
        {
            await _mediator.Send(updateCommand);
            return Ok("Adres bilgisi başarıyla güncellendi");
        }
    }
}
