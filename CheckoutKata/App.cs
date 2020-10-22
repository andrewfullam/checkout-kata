using CheckoutKata.Services.Abstractions;
using System;

namespace CheckoutKata
{
    class App
    {
        private readonly ICheckout _checkout;
        private readonly IRender _render;

        // Setup these using the static dependencies
        public App()
        {
            _checkout = StaticDependencies.Checkout;
            _render = StaticDependencies.Render;
        }

        // I've put the basic console UI stuff in here but this is probably better moved to a separate class. Just didn't have time.
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

                var output = _render.GetRenderOutputListString(checkoutItems, header, fullFooter);

                Console.WriteLine(output);
            }
        }
    }
}
