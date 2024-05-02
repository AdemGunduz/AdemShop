

using MediatR;

namespace AdemShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommand : IRequest
    {
        public Guid AddressId { get; set; }

        public DeleteAddressCommand(Guid addressId)
        {
            AddressId = addressId;
        }
    }
}
