using CheckoutKata.Models;
using CheckoutKata.Services;
using System.Collections.Generic;

namespace CheckoutKata
{
    class App
    {
        private readonly Checkout _checkout;
        private readonly RenderService<CheckoutItem> _renderService = new RenderService<CheckoutItem>();

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

            var promotions = new List<PromotionsBaseClass>
            {
                new PromotionsBaseClass
                {
                    Item = "A",
                    ApplyPromotion = () =>
                    {

                    }
                }
            }

            _checkout = new Checkout(priceList, promotions);
        }
    }
}
