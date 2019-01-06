﻿using System.Collections.Generic;
using WebStore.DomainNew.Models.Order;

namespace WebStore.DomainNew.Dto.Order
{
    public class CreateOrderModel
    {
        public OrderViewModel OrderViewModel { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}