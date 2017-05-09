using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout.Tests
{
    private WalesCarrierBagProvider carrierBagProvider = new WalesCarrierBagProvider();

    [TestClass]
    public class WalesCarrierBagTest
    {
        [TestMethod]
        public void WhenNoItemsScanned_NoBagChargeApplied()
        {
            var basket = new Basket(carrierBagProvider);
            Assert.AreEqual(0, basket.GetTotalPrice());
        }

        [TestMethod]
        public void WhenLessThanFiveItemsScanned_SingleBagChargeApplied()
        {
            var basket = new Basket(carrierBagProvider);
            var item1 = new Item('A', 10);

            basket.Scan(item1);

            Assert.AreEqual(20, basket.GetTotalPrice());
        }

        [TestMethod]
        public void WhenExactlyFiveItemsScanned_SingleBagChargeApplied()
        {
            var basket = new Basket(carrierBagProvider);
            var item1 = new Item('A', 10);
            var item2 = new Item('A', 10);
            var item3 = new Item('A', 10);
            var item4 = new Item('A', 10);
            var item5 = new Item('A', 10);

            basket.Scan(item1);
            basket.Scan(item2);
            basket.Scan(item3);
            basket.Scan(item4);
            basket.Scan(item5);

            Assert.AreEqual(60, basket.GetTotalPrice());
        }

        [TestMethod]
        public void WhenSixItemsScanned_TwoBagChargesApplied()
        {
            var basket = new Basket(carrierBagProvider);
            var item1 = new Item('A', 10);
            var item2 = new Item('A', 10);
            var item3 = new Item('A', 10);
            var item4 = new Item('A', 10);
            var item5 = new Item('A', 10);
            var item6 = new Item('A', 10);

            basket.Scan(item1);
            basket.Scan(item2);
            basket.Scan(item3);
            basket.Scan(item4);
            basket.Scan(item5);
            basket.Scan(item6);

            Assert.AreEqual(80, basket.GetTotalPrice());
        }
    }
}
