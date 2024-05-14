using AdemShop.Discount.Dto;
using AdemShop.Domain.Entities;
using Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace AdemShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly AdmContext _context;

        public DiscountService(AdmContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            var coupon = new Coupon
            {
                CouponId = Guid.NewGuid(), 
                Code = createCouponDto.Code,
                Rate = createCouponDto.Rate,
                IsActive = createCouponDto.IsActive,
                ValidDate = createCouponDto.ValidDate
            };

            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCouponAsync(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            return await _context.Coupons
                .Select(c => new ResultCouponDto
                {
                    CouponId = c.CouponId,
                    Code = c.Code,
                    Rate = c.Rate,
                    IsActive = c.IsActive,
                    ValidDate = c.ValidDate
                })
                .ToListAsync();
        }

        public async Task<GetIdCouponDto> GetIdCouponAsync(Guid id)
        {
            return await _context.Coupons
                .Where(c => c.CouponId == id)
                .Select(c => new GetIdCouponDto
                {
                    CouponId = c.CouponId,
                    Code = c.Code,
                    Rate = c.Rate,
                    IsActive = c.IsActive,
                    ValidDate = c.ValidDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            var coupon = await _context.Coupons.FindAsync(updateCouponDto.CouponId);
            if (coupon != null)
            {
                coupon.Code = updateCouponDto.Code;
                coupon.Rate = updateCouponDto.Rate;
                coupon.IsActive = updateCouponDto.IsActive;
                coupon.ValidDate = updateCouponDto.ValidDate;

                await _context.SaveChangesAsync();
            }
        }
    }

}
