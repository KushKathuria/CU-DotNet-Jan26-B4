using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Models;

namespace FinTrackPro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Assets> assets = new List<Assets>()
        {
            new Assets{ID=1,Name="HDFC Mid Cap",PurchasePrice=245,Type="MutualFund",PurchaseDate=new DateOnly(2020,1,1)},
            new Assets{ID=2,Name="SBI Gold Fund",PurchasePrice=1250,Type="Stock",PurchaseDate=new DateOnly(2011,3,27)},
            new Assets{ID=3,Name="Silver ETF",PurchasePrice=348,Type="MutualFund",PurchaseDate=new DateOnly(2015,11,1)},
            new Assets{ID=4,Name="AMJ Land Holding",PurchasePrice=526,Type="Stock",PurchaseDate=new DateOnly(2025,9,17)}
        };

        public IActionResult Index()
        {
            var total = assets.Sum(x => x.PurchasePrice);
            ViewData["Total"] = total;

            return View(assets);
        }

        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(x => x.ID == id);

            if (asset == null)
                return NotFound();

            return View(asset);
        }

        public IActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(x => x.ID == id);

            if (asset != null)
            {
                assets.Remove(asset);
                TempData["Message"] = "Asset deleted successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}