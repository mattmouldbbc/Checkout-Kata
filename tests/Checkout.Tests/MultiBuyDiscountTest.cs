using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkout.Tests
{
    [TestClass]
    public class MultiBuyDiscountTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenDiscountAppliedToLessThanOneItem_ExceptionThrown()
        {
            var discount = new MultiBuyDiscount(0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenDiscountTotalIsLessThanOne_ExceptionThrown()
        {
            var discount = new MultiBuyDiscount(3, 0);
        }
    }
}