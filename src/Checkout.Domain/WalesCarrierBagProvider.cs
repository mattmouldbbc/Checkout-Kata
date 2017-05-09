using System;
using Checkout.Interfaces;

namespace Checkout.Domain
{
    public class WalesCarrierBagProvider : ICarrierBagProvider
    {
        const int BagCharge = 10;
        const int ItemsPerBag = 5;

        public int CalculateTotalBagCharge(int itemCount)
        {
            if (itemCount == 0) return 0;

            return itemCount <= ItemsPerBag ? 1 * BagCharge : (int)Math.Ceiling((decimal)itemCount / ItemsPerBag) * BagCharge;
        }
    }
}