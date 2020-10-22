using CheckoutKata.Models;
using CheckoutKata.Services.Abstractions;
using CheckoutKata.Services.PromotionServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Services
{
    /* This class is responsible for the checkout functionality. Including adding to checkout and processing of promotions */
    public class Checkout : ICheckout
    {
        public List<CheckoutItem> _checkoutItems = new List<CheckoutItem>();
        private List<PriceList> _priceList;
        private List<IPromotions> _promotions;

        public int CheckoutTotal = 0;

        public Checkout(List<PriceList> priceList, List<IPromotions> promotions)
        {
            _priceList = priceList;
            _promotions = promotions;
        }

        public void AddToCheckout(string item)
        {
            // Find the existing checkout item, price list item and valid promotion for that item from within the 
            // applicable collections
            var checkoutItem = _checkoutItems.FirstOrDefault(c => c.Item == item);
            var priceListItem = _priceList.FirstOrDefault(p => p.Item == item);
            var validPromotion = _promotions.FirstOrDefault(p => p.GetItem(item) == item);

            // Check if checkout item exists
            if (checkoutItem != null)
            {
                // If the checkout item exists then increment by one. There is nothing in the spec related to delete or multiple additions
                // so this works for this spec. Obviously real world this would need to handle this.
                checkoutItem.Qty = checkoutItem.Qty += 1;

                // if there is a valid promotion for the result then set the price based on the apply promotions method and set the label
                if (validPromotion != null)
                {
                    checkoutItem.Price = validPromotion.ApplyPromotions(checkoutItem.Qty);
                    checkoutItem.PromotionApplied = validPromotion.PromotionHit(checkoutItem.Qty) ? validPromotion.GetPromotionDescription(item) : "No promotion";
                }
                else
                {
                    // if no valid promotion then recalculate the price
                    if (priceListItem != null)
                    {
                        checkoutItem.Price = priceListItem.Price * checkoutItem.Qty;
                    }
                    else
                    {
                        // If no price in price list for this item then something has gone wrong
                        throw new Exception("Unable to find price for item");
                    }
                }
            }
            else
            {
                // If no existing checkout item then add new entry to collection
                _checkoutItems.Add(new CheckoutItem
                {
                    Item = item,
                    Price = priceListItem.Price,
                    Qty = 1,
                    PromotionApplied = "No Promotion"
                });
            }
        }

        // Returns total based on the price in the checkout items collection
        public double GetTotal() => _checkoutItems.Sum(c => c.Price);

        // Returns checkout item list
        public List<CheckoutItem> GetCheckout()
        {
            return _checkoutItems;
        }
    }
}
