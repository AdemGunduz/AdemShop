using AdemShop.Order.Application.Features.CQRS.Results.AddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Application.Features.CQRS.Queries.AddressQuery
{
    public class GetAddressQuery : IRequest<GetAddressQueryResult>
    {
        public Guid AddressId { get; set; }

        public GetAddressQuery(Guid addressId)
        {
            AddressId = addressId;
        }
    }
}
