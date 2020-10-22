using CheckoutKata.Models;
using CheckoutKata.Services;
using CheckoutKata.Services.Abstractions;
using CheckoutKata.Services.PromotionServices;
using CheckoutKata.Services.PromotionServices.Abstractions;
using System.Collections.Generic;

namespace CheckoutKata
{
    public static class StaticDependencies
    {
        /* To save having to install third party library to handle dependency injection I'm going to use this static dependencies
         * class to mimic the functionality in a really basic simple way. Not great but better than newing up in classes */
        public static ICheckout Checkout;
        public static IRender Render;

        public static void Init()
        {
            // Setting up price list collection and promotions collection here to be used with checkout
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

            Checkout = new Checkout(priceList, promotions);
            Render = new Render();
        }
    }
}
