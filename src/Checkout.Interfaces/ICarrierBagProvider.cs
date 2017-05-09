namespace Checkout.Interfaces
{
    public interface ICarrierBagProvider
    {
        int CalculateTotalBagCharge(int itemCount);
    }
}
