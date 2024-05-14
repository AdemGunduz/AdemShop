using AdemShop.Domain.Entities;
using AdemShop.Order.Application.Features.CQRS.Queries.AddressQuery;
using AdemShop.Order.Application.Features.CQRS.Results.AddressResults;
using AdemShop.Order.Application.Interfaces;
using MediatR;


namespace AdemShop.Order.Application.Features.CQRS.Handlers.AddressHandler
{
    public class AddressQueryHandler : IRequestHandler<GetAddressQuery, GetAddressQueryResult>,
                                       IRequestHandler<GetAllAddressQuery, List<GetAllAddressQueryResult>>
    {
        private readonly IRepository<Address> _repository;

        public AddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressQueryResult> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetIdAsync(request.AddressId);
            return new GetAddressQueryResult
            {
                District = data.District,
                City = data.City,
                UserId = data.UserId,
                Detail = data.Detail,
                AddressId = data.AddressId,
            };
        }

        public async Task<List<GetAllAddressQueryResult>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return data.Select(a => new GetAllAddressQueryResult
            {
                AddressId = a.AddressId,
                UserId = a.UserId,
                District = a.District,
                City = a.City,
                Detail = a.Detail
            }).ToList();
        }
    }
}
