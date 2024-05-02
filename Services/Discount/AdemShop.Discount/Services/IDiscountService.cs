using AdemShop.Discount.Dto;

namespace AdemShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(Guid id);
        Task<GetIdCouponDto> GetIdCouponAsync(Guid id);
    }
}
