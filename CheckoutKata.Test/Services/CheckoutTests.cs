using CheckoutKata.Models;
using CheckoutKata.Services;
using CheckoutKata.Services.Abstractions;
using CheckoutKata.Services.PromotionServices;
using CheckoutKata.Services.PromotionServices.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Test
{
    [TestClass]
    public class CheckoutTests
    {
        ICheckout _checkout;

        [TestInitialize]
        public void Init()
        {
            var priceList = new List<PriceList>
            {
                new PriceList
                {
                    Item = "A",
                    Price = 10
                },
                new PriceList
                {
                    Item = "B",
                    Price = 15
                },
                new PriceList
                {
                    Item = "C",
                    Price = 40
                },
                new PriceList
                {
                    Item = "D",
                    Price = 55
                }
            };

            var promotions = new List<IPromotions>
            {
                new ItemBPromotion("B", priceList.Find(p => p.Item == "B").Price, "3 for 40", 3),
                new ItemDPromotion("D", priceList.Find(p => p.Item == "D").Price, "25% off for every 2 purchased together", 2)
            };

            _checkout = new Checkout(priceList, promotions);
        }

        [TestMethod]
        public void AddToCheckout_AddItem_ReturnsCorrectItems()
        {
            // Arrange
            var item = "B";

            // Act
            _checkout.AddToCheckout(item);

            var result = _checkout.GetCheckout();

            var testItem = result.FirstOrDefault(r => r.Item == item);

            // Assert
            Assert.AreEqual(item, testItem.Item);
            Assert.AreEqual(1, testItem.Qty);
            Assert.AreEqual(15, testItem.Price);
        }

        [TestMethod]
        public void AddToCheckout_AddItems_CalculatesCorrectPromoB()
        {
            // Arrange
            var item = "B";

            // Act
            _checkout.AddToCheckout(item);
            _checkout.AddToCheckout(item);
            _checkout.AddToCheckout(item);

            var result = _checkout.GetCheckout();

            var testItem = result.FirstOrDefault(r => r.Item == item);

            // Assert
            Assert.AreEqual(3, testItem.Qty);
            Assert.AreEqual(40, testItem.Price);
            Assert.AreEqual("3 for 40", testItem.PromotionApplied);
        }

        [TestMethod]
        public void AddToCheckout_AddItems_CalculatesCorrectPromoD()
        {
            // Arrange
            var item = "D";

            // Act
            _checkout.AddToCheckout(item);
            _checkout.AddToCheckout(item);

            var result = _checkout.GetCheckout();

            var testItem = result.FirstOrDefault(r => r.Item == item);

            // Assert
            Assert.AreEqual(2, testItem.Qty);
            Assert.AreEqual(82.5, testItem.Price);
            Assert.AreEqual("25% off for every 2 purchased together", testItem.PromotionApplied);
        }
    }
}
