using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Application.Features.Mediator.Commands.OrderingCommand
{
    public class UpdateOrderingCommand : IRequest
    {
        public Guid OrderingId { get; set; }
        public Guid UsingId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
