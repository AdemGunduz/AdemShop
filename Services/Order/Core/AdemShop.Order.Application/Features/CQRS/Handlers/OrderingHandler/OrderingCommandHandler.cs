using AdemShop.Domain.Entities;
using AdemShop.Order.Application.Features.Mediator.Commands.OrderingCommand;
using AdemShop.Order.Application.Interfaces;
using MediatR;


namespace AdemShop.Order.Application.Features.Mediator.Handlers.OrderingHandler
{
    public class OrderingCommandHandler : IRequestHandler<CreateOrderingCommand>,
                                          IRequestHandler<DeleteOrderingCommand>,
                                          IRequestHandler<UpdateOrderingCommand>
    {

        private readonly IRepository<Ordering> _repository;

        public OrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UsingId = request.UsingId,
            });
        }

        public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.OrderingId);
            await _repository.DeleteAsync(data);
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.OrderingId);
            data.TotalPrice = request.TotalPrice;
            data.UsingId = request.UsingId;
            data.UsingId = request.UsingId;
            
            await _repository.UpdateAsync(data);
        }
    }
}
