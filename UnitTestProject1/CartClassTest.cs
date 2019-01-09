using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStore.DomainNew.Models.Cart;
using WebStore.DomainNew.Models.Product;
using Assert = Xunit.Assert;

namespace WebStore.UnitTests
{
    [TestClass]
    public class CartClassTest
    {
        [TestMethod]
        public void Cart_Class_ItemsCount_Returns_Correct_Quantity()
        {
            var cart = new Cart()
            {
                Items = new List<CartItem>()
                {
                new CartItem()
                {
                ProductId = 1,
                Quantity = 1
            },
            new CartItem()
            {
                ProductId = 3,
                Quantity = 3
            }
            }
            };
            var result = cart.ItemsCount;
            Assert.Equal(4, result);
        }
        [TestMethod]
        public void CartViewModel_Returns_Correct_ItemsCount()
        {
            var cartViewModel = new CartViewModel()
            {
                Items = new Dictionary<ProductViewModel, int>()
                {
                    {
                        new ProductViewModel()
                        {
                            Id = 1,
                            Name = "TestItem",
                            Price = 5.0m
                        },
                        1
                    },
                    {
                        new ProductViewModel()
                        {
                            Id = 2,
                            Name = "TestItem2",
                            Price = 1.0m
                        },
                        2
                    },
                }
            };
            var result = cartViewModel.ItemsCount;
            Assert.Equal(3, result);
        }

    }
}