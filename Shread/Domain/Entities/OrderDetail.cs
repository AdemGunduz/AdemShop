namespace AdemShop.Domain.Entities
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName{ get; set; }
        public string ProductPrice{ get; set; }
        public string ProductAmount{ get; set; }
        public string ProductTotalPrice{ get; set; }
        public Guid OrderingId { get; set; }
        public Ordering Ordering { get; set; }
    }
}
