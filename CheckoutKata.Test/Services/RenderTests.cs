using CheckoutKata.Models;
using CheckoutKata.Services;
using CheckoutKata.Services.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CheckoutKata.Test.Services
{
    [TestClass]
    public class RenderTests
    {
        IRender _render = new Render();

        [TestMethod]
        public void RenderOutputList_WithItems_RendersItemsInString()
        {
            // Arrange
            var checkoutItemList = new List<CheckoutItem>
            {
                new CheckoutItem
                {
                    Item = "B",
                    Qty = 2,
                    Price = 3,
                    PromotionApplied = "This is the promotion text"
                }
            };

            // Act
            var result = _render.GetRenderOutputListString(checkoutItemList, "", "");

            // Assert
            Assert.AreEqual(true, result.Contains("B | 3 | 2 | This is the promotion text"));
        }

        [TestMethod]
        public void RenderOutputList_WithHeader_ReturnsHeaderInString()
        {
            // Arrange
            var checkoutItemList = new List<CheckoutItem>();

            // Act
            var result = _render.GetRenderOutputListString(checkoutItemList, "Test Header", "");

            // Assert
            Assert.AreEqual(true, result.Contains("Test Header"));
        }

        [TestMethod]
        public void RenderOutputList_WithHeader_ReturnsFooterInString()
        {
            // Arrange
            var checkoutItemList = new List<CheckoutItem>();

            // Act
            var result = _render.GetRenderOutputListString(checkoutItemList, "Test Footer", "");

            // Assert
            Assert.AreEqual(true, result.Contains("Test Footer"));
        }
    }
}
