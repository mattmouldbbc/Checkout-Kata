namespace Checkout.Interfaces
{
    public interface IBasket
    {
        void Scan(IItem item);
        int GetTotalPrice();
    }
}