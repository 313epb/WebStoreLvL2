﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Dto.Order;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Models.Cart;
using WebStore.DomainNew.Models.Order;
using WebStore.Interfaces;

namespace WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    public class OrdersApiController : Controller,IOrdersService
    {
        private readonly IOrdersService _ordersService;

        public OrdersApiController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("{userName}")]
        public IEnumerable<OrderDto> GetUserOrders(string userName)
        {
            return _ordersService.GetUserOrders(userName);
        }

        [HttpGet("{id}")]
        public OrderDto GetOrderById(int id)
        {
            return _ordersService.GetOrderById(id);
        }

        [HttpPost("{userName}")]
        public OrderDto CreateOrder([FromBody]CreateOrderModel orderModel, string userName)
        {
            return _ordersService.CreateOrder(orderModel, userName);
        }
    }
}