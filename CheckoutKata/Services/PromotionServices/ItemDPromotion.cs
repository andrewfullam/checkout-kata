using CheckoutKata.Services.PromotionServices.Abstractions;

namespace CheckoutKata.Services.PromotionServices
{
    public class ItemDPromotion : Promotions, IPromotions
    {
        public ItemDPromotion(string item, int basePrice, string promotionDescription, int triggerQty) : base(item, basePrice, promotionDescription, triggerQty)
        {

        }

        public override int ApplyPromotions(int qty)
        {
            var totalPromotions = qty / TriggerQty;
            var remainder = qty % TriggerQty;
            var promotionalPrice = 0;

            for (var i = 0; i < totalPromotions; i++)
            {
                promotionalPrice += BasePrice / 100 * 75;
            }

            return promotionalPrice += remainder * BasePrice;
        }
    }
}
