using AdemShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using AdemShop.Order.Application.Features.Mediator.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetAlllOrderingQuery : IRequest<List<GetAllOrderingResult>>
    {
    }
}
