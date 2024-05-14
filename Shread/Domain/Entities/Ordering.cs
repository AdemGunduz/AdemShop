namespace AdemShop.Domain.Entities
{
    public class Ordering
    {
        public Guid OrderingId { get; set; }
        public Guid UsingId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
