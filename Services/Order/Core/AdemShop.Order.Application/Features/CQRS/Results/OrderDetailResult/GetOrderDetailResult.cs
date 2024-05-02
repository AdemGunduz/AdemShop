﻿using AdemShop.Order.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdemShop.Order.Application.Features.CQRS.Results.OrderDetailResult
{
    public class GetOrderDetailResult
    {
        public Guid OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductAmount { get; set; }
        public string ProductTotalPrice { get; set; }
        public Guid OrderingId { get; set; }
        public Ordering Ordering { get; set; }
    }
}