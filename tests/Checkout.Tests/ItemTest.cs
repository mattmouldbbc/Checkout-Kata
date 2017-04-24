using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkout.Domain;

namespace Checkout.Tests
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenUnitPriceIsLessThanOne_ExceptionThrown()
        {
            var item = new Item('A', 0);
        }
    }
}