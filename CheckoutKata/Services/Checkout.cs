using CheckoutKata.Models;
using System.Collections.Generic;

namespace CheckoutKata.Services
{
    public class Checkout
    {
        public List<CheckoutItem> _checkoutItems = new List<CheckoutItem>();

        private PriceList _priceList;

        private Promotions _promotions;

        public int CheckoutTotal = 0;

        public Checkout(PriceList priceList, Promotions promotions)
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
