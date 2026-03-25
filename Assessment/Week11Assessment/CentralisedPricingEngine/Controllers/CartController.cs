using System.Collections.Generic;
using System.Linq;
using CentralisedPricingEngine.Services;
using CentralisedPricingEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CentralisedPricingEngine.Controllers
{
    public class CartController : Controller
    {
        private readonly IPricingService _pricingService;

        private static List<Product> cartItems = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000, PromoCode = "" },
            new Product { Id = 2, Name = "Headphones", Price = 3000, PromoCode = "" }
        };

        public CartController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        // Show cart and apply optional promo code to each item
        public IActionResult Index(string code)
        {
            code ??= string.Empty;

            // Apply promo to every cart item and compute discounted price
            foreach (var item in cartItems)
            {
                item.PromoCode = code;
                item.DiscountedPrice = string.IsNullOrWhiteSpace(code)
                    ? item.Price
                    : _pricingService.CalculatePrice(item.Price, code);
            }

            var grandTotal = cartItems.Sum(i => i.DiscountedPrice);

            ViewBag.GrandTotal = grandTotal;
            ViewBag.SelectedPromo = code;

            // Pass the list as the model to the view
            return View(cartItems);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            ViewBag.PromoCodes = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Select Promo Code", Value = "" },
                new SelectListItem { Text = "WINTER25", Value = "WINTER25" },
                new SelectListItem { Text = "FREESHIP", Value = "FREESHIP" }
            };

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(string promoCode)
        {
            // normalize incoming value
            promoCode ??= string.Empty;

            // apply promo to all cart items (keeps state)
            foreach (var item in cartItems)
            {
                item.PromoCode = promoCode;
                item.DiscountedPrice = string.IsNullOrWhiteSpace(promoCode)
                    ? item.Price
                    : _pricingService.CalculatePrice(item.Price, promoCode);
            }

            // Redirect to Index so the cart page shows updated discounted prices
            return RedirectToAction(nameof(Index), new { code = promoCode });
        }
    }
}