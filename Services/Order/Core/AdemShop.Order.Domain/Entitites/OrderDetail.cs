using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Domain.Entitites
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
