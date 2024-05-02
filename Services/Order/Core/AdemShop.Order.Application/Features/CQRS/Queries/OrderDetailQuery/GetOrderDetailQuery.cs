

using AdemShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MediatR;

namespace AdemShop.Order.Application.Features.CQRS.Queries.OrderDetailQuery
{
    public class GetOrderDetailQuery  : IRequest<GetOrderDetailResult>
    {
        public Guid OrderDetailId { get; set; }

        public GetOrderDetailQuery(Guid orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}
