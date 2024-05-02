using AdemShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Application.Features.CQRS.Queries.OrderDetailQuery
{
    public class GetAllOrderDetailQuery :IRequest<List<GetAllOrderDetailResult>>
    {
    }
}
