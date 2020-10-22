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
        public void RenderOutputList_WithItems_RendersItems()
        {
            // Arrange
            var checkoutItemList = new List<CheckoutItem>
            {
                new CheckoutItem
                {
                    Item = "B",
                    Qty = 2,
                    Price = 3,
                    PromotionApplied = "Test"
                }
            };
        }
    }
}
