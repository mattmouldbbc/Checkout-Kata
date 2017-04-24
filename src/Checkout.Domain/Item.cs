using System;
using Checkout.Interfaces;

namespace Checkout.Domain
{
    public class Item : IItem
    {
        public char SKU { get; }
        public int UnitPrice { get; }
        public IDiscount Discount { get; }

        public Item(char sku, int unitPrice, IDiscount discount = null)
        {
            if (unitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero", nameof(unitPrice));

            SKU = sku;
            UnitPrice = unitPrice;
            Discount = discount;
        }
    }
}