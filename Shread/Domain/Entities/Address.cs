namespace AdemShop.Domain.Entities
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
