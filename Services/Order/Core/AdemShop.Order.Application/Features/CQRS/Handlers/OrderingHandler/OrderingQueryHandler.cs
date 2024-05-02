using AdemShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using AdemShop.Order.Application.Features.Mediator.Results;
using AdemShop.Order.Application.Interfaces;
using AdemShop.Order.Domain.Entitites;
using MediatR;

namespace AdemShop.Order.Application.Features.Mediator.Handlers.OrderingHandler
{
    public class OrderingQueryHandler : IRequestHandler<GetAlllOrderingQuery, List<GetAllOrderingResult>>,
                                        IRequestHandler<GetOrderingQuery, GetOrderingResult>
    { 
        private readonly IRepository<Ordering> _repository;

        public OrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllOrderingResult>> Handle(GetAlllOrderingQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return data.Select(x => new GetAllOrderingResult
            {
                OrderingId = x.OrderingId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UsingId = x.UsingId
            }).ToList();
        }

        public async Task<GetOrderingResult> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.OrderingId);
            return new GetOrderingResult
            {
                OrderDate = data.OrderDate,
                OrderingId = data.OrderingId,
                TotalPrice = data.TotalPrice,
                UsingId = data.UsingId
            };
        }
    }
}
