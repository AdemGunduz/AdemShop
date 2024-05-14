namespace AdemShop.Domain.Entities
{
    public class Coupon
    {
        public Guid CouponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
