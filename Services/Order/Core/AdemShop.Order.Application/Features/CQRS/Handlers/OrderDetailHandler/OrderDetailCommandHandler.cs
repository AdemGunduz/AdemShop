using AdemShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using AdemShop.Order.Application.Interfaces;
using AdemShop.Order.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler
{
    public class OrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand>,
                                             IRequestHandler<UpdateOrderDetailCommand>,
                                             IRequestHandler<DeleteOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;

        public OrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductAmount = request.ProductAmount,
                OrderingId = request.OrderingId,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductTotalPrice = request.ProductTotalPrice,
            });
        }

        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.OrderDetailId);
            data.OrderingId = request.OrderDetailId;
            data.ProductId = request.ProductId;
            data.ProductPrice = request.ProductPrice;
            data.ProductName = request.ProductName;
            data.ProductTotalPrice = request.ProductTotalPrice;
            data.ProductAmount = request.ProductAmount;
            await _repository.UpdateAsync(data);
        }

        public async Task Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.OrderDetailId);
            await _repository.DeleteAsync(data);
        }
    }
}
