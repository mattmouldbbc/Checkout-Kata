using System;
using System.Linq;
using System.Collections.Generic;
using Checkout.Interfaces;

namespace Checkout.Domain
{
    public class MultiBuyDiscount : IDiscount
    {
        public int ItemsRequired { get; }
        public int DiscountTotal { get; }

        public MultiBuyDiscount(int numberOfItems, int discountTotal)
        {
            if (numberOfItems <= 0)
                throw new ArgumentException("Discounts can only apply to one or more items", nameof(numberOfItems));

            if (discountTotal <= 0)
                throw new ArgumentException("Discount total must be great than zero", nameof(discountTotal));

            ItemsRequired = numberOfItems;
            DiscountTotal = discountTotal;
        }

        /// <summary>
        /// Calculates the amount to deduct from the total price based on the discount
        /// </summary>
        /// <param name="items">All items in the basket which correspond to this discount</param>
        /// <returns>The discount to deduct from the total price</returns>
        public int CalculateDiscount(IEnumerable<IItem> items)
        {
            return (items.Count() / ItemsRequired) * DiscountTotal;
        }
    }
}