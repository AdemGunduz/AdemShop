

using MediatR;

namespace AdemShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class UpdateAddressCommand : IRequest
    {
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
