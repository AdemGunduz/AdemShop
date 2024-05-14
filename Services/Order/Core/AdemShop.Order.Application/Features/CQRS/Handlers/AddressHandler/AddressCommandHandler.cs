using AdemShop.Domain.Entities;
using AdemShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using AdemShop.Order.Application.Interfaces;
using MediatR;


namespace AdemShop.Order.Application.Features.CQRS.Handlers.AddressHandler
{
    public class AddressCommandHandler : IRequestHandler<CreateAddressCommand>,
                                         IRequestHandler<UpdateAddressCommand>,
                                         IRequestHandler<DeleteAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public AddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Address
            {
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserId = request.UserId
            });
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.AddressId);
            data.UserId = request.UserId;
            data.Detail = request.Detail;
            data.District = request.District;
            data.City = request.City;
            await _repository.UpdateAsync(data);
        }

        public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.AddressId);
            await _repository.DeleteAsync(data);
        }
    }
}
