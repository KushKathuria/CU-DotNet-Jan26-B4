using NorthWindCatalog.Services.DTOs;
using Xunit;

namespace NorthWind.Tests
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            var product = new ProductDto
            {
                ProductName = "Chai",
                UnitPrice = 20m,
                UnitsInStock = 10
            };

            Assert.Equal(200m, product.InventoryValue);
        }

        [Fact]
        public void InventoryValue_Should_Return_Zero_When_Stock_Is_Zero()
        {
            var product = new ProductDto
            {
                ProductName = "Chang",
                UnitPrice = 25m,
                UnitsInStock = 0
            };

            Assert.Equal(0m, product.InventoryValue);
        }

        [Fact]
        public void InventoryValue_Should_Return_Zero_When_Price_Is_Zero()
        {
            var product = new ProductDto
            {
                ProductName = "Aniseed Syrup",
                UnitPrice = 0m,
                UnitsInStock = 12
            };

            Assert.Equal(0m, product.InventoryValue);
        }
    }
}