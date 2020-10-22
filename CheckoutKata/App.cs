using CheckoutKata.Models;
using CheckoutKata.Services;
using CheckoutKata.Services.PromotionServices;
using CheckoutKata.Services.PromotionServices.Abstractions;
using System.Collections.Generic;

namespace CheckoutKata
{
    class App
    {
        private readonly ICheckout _checkout;
        private readonly IRenderService<CheckoutItem> _renderService = new RenderService<CheckoutItem>();

        public string header = "---------------------------------\n CHECKOUT \n---------------------------------\n";
        public string footer = "---------------------------------";

        public App()
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

        public void Run()
        {
            _checkout.AddToCheckout("B");
            _checkout.AddToCheckout("B");
            _checkout.AddToCheckout("B");
            _checkout.AddToCheckout("B");
            _checkout.AddToCheckout("B");
            _checkout.AddToCheckout("B");
            _checkout.AddToCheckout("D");

            var checkoutItems = _checkout.GetCheckout();

            var checkoutTotal = _checkout.GetTotal();

            _renderService.RenderOutputList(_checkout.GetCheckout(), header, footer);
        }
    }
}
