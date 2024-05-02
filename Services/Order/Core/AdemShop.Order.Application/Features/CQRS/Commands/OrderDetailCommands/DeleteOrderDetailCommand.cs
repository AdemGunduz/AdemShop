using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand : IRequest
    {
        public Guid OrderDetailId { get; set; }

        public DeleteOrderDetailCommand(Guid orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}
