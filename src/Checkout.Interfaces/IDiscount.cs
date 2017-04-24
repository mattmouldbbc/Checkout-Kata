using System.Collections.Generic;

namespace Checkout.Interfaces
{
    public interface IDiscount
    {
        int CalculateDiscount(IEnumerable<IItem> items);
    }
}