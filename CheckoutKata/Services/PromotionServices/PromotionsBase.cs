using System;

namespace CheckoutKata.Services.PromotionServices
{
    public class Promotions
    {
        protected readonly string Item;

        protected readonly int BasePrice;

        protected readonly string PromotionDescription;

        protected readonly int TriggerQty;

        public Promotions(string item, int basePrice, string promotionDescription, int triggerQty)
        {
            Item = item;
            BasePrice = basePrice;
            PromotionDescription = promotionDescription;
            TriggerQty = triggerQty;
        }

        public virtual int ApplyPromotions(int qty)
        {
            throw new NotImplementedException();
        }

        public string GetItem(string item)
        {
            return Item;
        }

        public string GetPromotionDescription(string item)
        {
            return PromotionDescription;
        }

        public bool PromotionHit(int qty) => qty >= TriggerQty;
    }
}
