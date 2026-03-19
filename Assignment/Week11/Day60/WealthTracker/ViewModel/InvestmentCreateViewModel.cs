using System.ComponentModel.DataAnnotations;

namespace WealthTracker.ViewModel
{
    public class InvestmentCreateViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "Ticker symbol cannot exceed 10 characters.")]
        [Display(Name = "Ticker Symbol")]
        public string TickerSymbol { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Asset Name")]
        public string AssetName { get; set; }

        [Required]
        [Range(0.01, 10000000)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 1000000)]
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity; 
    }
}