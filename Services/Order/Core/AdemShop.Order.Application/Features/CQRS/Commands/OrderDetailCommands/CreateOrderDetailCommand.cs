
using AdemShop.Domain.Entities;
using MediatR;


namespace AdemShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand :IRequest
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductAmount { get; set; }
        public string ProductTotalPrice { get; set; }
        public Guid OrderingId { get; set; }
        public Ordering Ordering { get; set; }
    }
}
