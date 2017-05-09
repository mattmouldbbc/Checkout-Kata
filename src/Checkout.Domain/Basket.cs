using System;
using System.Linq;
using System.Collections.Generic;
using Checkout.Interfaces;

namespace Checkout.Domain
{
    public class Basket : IBasket
    {
        private List<IItem> _items = new List<IItem>();
        private ICarrierBagProvider _carrierBagProvider;

        public Basket(ICarrierBagProvider carrierBagProvider)
        {
            if (carrierBagProvider == null)
                throw new ArgumentNullException(nameof(carrierBagProvider));

            _carrierBagProvider = carrierBagProvider;
        }

        /// <summary>
        /// Scan a new item and add it to the shopping basket
        /// </summary>
        /// <param name="item">The item to add to the basket</param>
        public void Scan(IItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _items.Add(item);
        }

        /// <summary>
        /// Calculates the total cost of all items in the basket
        /// </summary>
        /// <returns>Total price of all items including discount</returns>
        public int GetTotalPrice()
        {
            var basketTotal = _items.Sum(i => i.UnitPrice);

            // Deduct any discounts from the sum total
            var discountedSkus = _items.Where(i => i.Discount != null).Select(i => i.SKU).Distinct();
            foreach (char sku in discountedSkus)
            {
                var skuItems = _items.Where(item => item.SKU == sku);
                if (skuItems.Any())
                {
                    basketTotal -= skuItems.First().Discount.CalculateDiscount(skuItems);
                }
            }

            basketTotal += _carrierBagProvider.CalculateTotalBagCharge(_items.Count);

            return basketTotal;
        }
    }
}