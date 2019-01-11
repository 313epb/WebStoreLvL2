﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore.DomainNew.Filters;
using WebStore.DomainNew.Models.Cart;
using WebStore.DomainNew.Models.Product;
using WebStore.Interfaces;

namespace WebStore.Services
{
    public class CookieCartService : ICartService
    {
        private readonly IProductData _productData;
        private readonly ICartStore _cartStore;


        public CookieCartService(IProductData productData, ICartStore cartStore)
        {
            _productData = productData;
            _cartStore = cartStore;
        }

        public void DecrementFromCart(int id)
        {
            var cart = _cartStore.Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                if (item.Quantity > 0)
                    item.Quantity--;

                if (item.Quantity == 0)
                    cart.Items.Remove(item);
            }

            _cartStore.Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = _cartStore.Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
            _cartStore.Cart = cart;
        }

        public void RemoveAll()
        {
            _cartStore.Cart.Items.Clear();
        }

        public void AddToCart(int id)
        {
            var cart = _cartStore.Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
                item.Quantity++;
            else
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });

            _cartStore.Cart = cart;
        }

        public CartViewModel TransformCart()
        {
            var products = _productData.GetProducts(new ProductFilter()
            {
                Ids = _cartStore.Cart.Items.Select(i => i.ProductId).ToList()
            }).Products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                Brand = p.Brand != null ? p.Brand.Name : string.Empty
            }).ToList();

            var r = new CartViewModel
            {
                Items = _cartStore.Cart.Items.ToDictionary(x => products.First(y => y.Id == x.ProductId), x => x.Quantity)
            };

            return r;
        }
    }
}
