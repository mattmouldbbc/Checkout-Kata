namespace Checkout.Interfaces
{
    public interface IItem
    {
        char SKU { get; }
        int UnitPrice { get; }
        IDiscount Discount { get; }
    }
}