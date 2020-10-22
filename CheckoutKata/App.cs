using CheckoutKata.Models;
using CheckoutKata.Services;
using CheckoutKata.Services.Abstractions;
using CheckoutKata.Services.PromotionServices;
using CheckoutKata.Services.PromotionServices.Abstractions;
using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    class App
    {
        private readonly ICheckout _checkout;
        private readonly IRender _renderService = new Render();

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
            var header = "---------------------------------\n CHECKOUT \n---------------------------------\n";
            var footer = "---------------------------------\n";

            var input = "";

            while (input != "exit")
            {
                Console.WriteLine("\n\nAvailable items: \nA - Price: 10\nB - Price: 15\nC - Price: 40\nD - Price: 55\n");
                Console.WriteLine("Please add an item to the checkout (type the corresponding letter to add it or exit to quit): ");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "A":
                        _checkout.AddToCheckout("A");
                        break;
                    case "B":
                        _checkout.AddToCheckout("B");
                        break;
                    case "C":
                        _checkout.AddToCheckout("C");
                        break;
                    case "D":
                        _checkout.AddToCheckout("D");
                        break;
                    case "exit":
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }

                Console.Clear();

                var checkoutItems = _checkout.GetCheckout();

                var checkoutTotal = _checkout.GetTotal();

                var fullFooter = $"{footer} Total      {checkoutTotal}      \n{footer}";

                var output = _renderService.GetRenderOutputListString(checkoutItems, header, fullFooter);

                Console.WriteLine(output);
            }
        }
    }
}
