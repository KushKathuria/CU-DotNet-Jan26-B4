namespace CentralisedPricingEngine.Services
{
    public class PricingService : IPricingService
    {
        public decimal CalculatePrice(decimal Price, string PromoCode)
        {
            if (PromoCode == "WINTER25")
            {
                return Price * 0.85m;
            }
            if (PromoCode == "FREESHIP")
            {
                return Price - 5;
            }
            Console.WriteLine("Invalid Promo Code Applied");

            return Price < 0 ? 0 : Price;
        }
    }
}
