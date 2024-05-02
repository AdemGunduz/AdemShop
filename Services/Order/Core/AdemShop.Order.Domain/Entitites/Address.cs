using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Domain.Entitites
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
