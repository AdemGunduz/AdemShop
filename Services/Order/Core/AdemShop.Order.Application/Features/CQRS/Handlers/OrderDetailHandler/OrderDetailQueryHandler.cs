using AdemShop.Domain.Entities;
using AdemShop.Order.Application.Features.CQRS.Queries.AddressQuery;
using AdemShop.Order.Application.Features.CQRS.Queries.OrderDetailQuery;
using AdemShop.Order.Application.Features.CQRS.Results.AddressResults;
using AdemShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using AdemShop.Order.Application.Interfaces;
using MediatR;

namespace AdemShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandler
{
    public class OrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, GetOrderDetailResult>,
                                           IRequestHandler<GetAllOrderDetailQuery, List<GetAllOrderDetailResult>>
    { 
        private readonly IRepository<OrderDetail> _repository;

        public OrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailResult> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.OrderDetailId);
            return new GetOrderDetailResult
            {
                OrderDetailId = data.OrderDetailId,
                ProductAmount = data.ProductAmount,
                ProductName = data.ProductName,
                ProductId = data.ProductId,
                OrderingId = data.OrderingId,
                ProductPrice = data.ProductPrice,
                ProductTotalPrice = data.ProductTotalPrice,
            };
        }

        public async Task<List<GetAllOrderDetailResult>> Handle(GetAllOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return data.Select(x => new GetAllOrderDetailResult
            {
                OrderDetailId = x.OrderDetailId,
                ProductAmount = x.ProductAmount,
                OrderingId = x.OrderingId,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice,
            }).ToList();
        }
    }
}
