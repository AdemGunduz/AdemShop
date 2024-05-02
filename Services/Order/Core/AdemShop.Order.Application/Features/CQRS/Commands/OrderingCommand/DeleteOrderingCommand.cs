using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Application.Features.Mediator.Commands.OrderingCommand
{
    public class DeleteOrderingCommand : IRequest
    {
        public DeleteOrderingCommand(Guid orderingId)
        {
            OrderingId = orderingId;
        }

        public Guid OrderingId { get; set; }
    }
}
