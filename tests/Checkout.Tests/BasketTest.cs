﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout.Tests
{
    [TestClass]
    public class BasketTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenNullItemScanned_ExceptionThrown()
        {
            var basket = new Basket();
            basket.Scan(null);
        }

        [TestMethod]
        public void WhenNoItemsScanned_TotalIsZero()
        {
            var basket = new Basket();
            Assert.AreEqual(0, basket.GetTotalPrice());
        }

        [TestMethod]
        public void WhenNonDiscountedItemsOnly_TotalIsCorrect()
        {
            var basket = new Basket();
            var item1 = new Item('A', 10);
            var item2 = new Item('B', 20);

            basket.Scan(item1);
            basket.Scan(item2);

            Assert.AreEqual(30, basket.GetTotalPrice());
        }

        [TestMethod]
        public void WhenItemsDiscounted_TotalIsCorrect()
        {
            var basket = new Basket();
            var discount = new MultiBuyDiscount(2, 10);
            var item1 = new Item('A', 20, discount);
            var item2 = new Item('A', 20, discount);

            basket.Scan(item1);
            basket.Scan(item2);

            Assert.AreEqual(30, basket.GetTotalPrice());
        }

        [TestMethod]
        public void WhenMixOfDiscountAndNonDiscountItems_TotalIsCorrect()
        {
            var basket = new Basket();

            var buyThreeSave20 = new MultiBuyDiscount(3, 20);
            var apple = new Item('A', 50, buyThreeSave20);

            var buyTwoSave15 = new MultiBuyDiscount(2, 15);
            var grape = new Item('B', 30, buyTwoSave15);

            var cherry = new Item('C', 20);
            var melon = new Item('D', 15);

            basket.Scan(apple);
            basket.Scan(apple);
            basket.Scan(apple);
            basket.Scan(grape);
            basket.Scan(grape);
            basket.Scan(cherry);
            basket.Scan(melon);

            Assert.AreEqual(210, basket.GetTotalPrice());
        }
    }
}