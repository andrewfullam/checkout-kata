using CheckoutKata.Models;
using System.Collections.Generic;

namespace CheckoutKata.Services
{
    public class Checkout
    {
        public List<CheckoutItem> _checkoutItems = new List<CheckoutItem>();
        private PriceList _priceList;
        private PromotionsBaseClass _promotions;
        private readonly RenderService<CheckoutItem> _renderService;

        public int CheckoutTotal = 0;

        public Checkout(PriceList priceList, PromotionsBaseClass promotions)
        {
            _priceList = priceList;
            _promotions = promotions;
        }

        public void AddToCheckout(string item)
        {

        }

        public List<CheckoutItem> GetCheckout()
        {
            return _checkoutItems;
        }
    }
}
