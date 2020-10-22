using CheckoutKata.Models;
using CheckoutKata.Services.Abstractions;
using CheckoutKata.Services.PromotionServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Services
{
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
            var checkoutItem = _checkoutItems.FirstOrDefault(c => c.Item == item);
            var priceListItem = _priceList.FirstOrDefault(p => p.Item == item);
            var validPromotion = _promotions.FirstOrDefault(p => p.GetItem(item) == item);

            if (checkoutItem != null)
            {
                checkoutItem.Qty = checkoutItem.Qty += 1;

                if (validPromotion != null)
                {
                    checkoutItem.Price = validPromotion.ApplyPromotions(checkoutItem.Qty);
                    checkoutItem.PromotionApplied = validPromotion.PromotionHit(checkoutItem.Qty) ? validPromotion.GetPromotionDescription(item) : "No promotion";
                }
                else
                {
                    if (priceListItem != null)
                    {
                        checkoutItem.Price = priceListItem.Price * checkoutItem.Qty;
                    }
                    else
                    {
                        throw new Exception("Unable to find price for item");
                    }
                }
            }
            else
            {
                _checkoutItems.Add(new CheckoutItem
                {
                    Item = item,
                    Price = priceListItem.Price,
                    Qty = 1,
                    PromotionApplied = "No Promotion"
                });
            }
        }

        public int GetTotal() => _checkoutItems.Sum(c => c.Price);

        public List<CheckoutItem> GetCheckout()
        {
            return _checkoutItems;
        }
    }
}
