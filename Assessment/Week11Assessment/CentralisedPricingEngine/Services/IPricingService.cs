namespace CentralisedPricingEngine.Services
{
    public interface IPricingService
    {
        decimal CalculatePrice(decimal Price, string PromoCode);
    }
}
