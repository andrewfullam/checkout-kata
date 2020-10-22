namespace CheckoutKata.Services.PromotionServices
{
    public class ItemDPromotion : Promotions
    {
        public ItemDPromotion(string item, double basePrice, string promotionDescription, int triggerQty) : base(item, basePrice, promotionDescription, triggerQty)
        {

        }

        public override double ApplyPromotions(int qty)
        {
            var totalPromotions = qty / TriggerQty;
            var remainder = qty % TriggerQty;
            var promotionalPrice = 0.00;

            for (var i = 0; i < totalPromotions; i++)
            {
                promotionalPrice += ((BasePrice * TriggerQty) / 100) * 75;
            }

            return promotionalPrice += remainder * BasePrice;
        }
    }
}
