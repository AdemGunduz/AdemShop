

using MediatR;

namespace AdemShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class CreateAddressCommand  : IRequest
    {
        public Guid UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
