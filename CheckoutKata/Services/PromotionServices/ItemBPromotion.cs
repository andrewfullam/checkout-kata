using CheckoutKata.Services.PromotionServices.Abstractions;

namespace CheckoutKata.Services.PromotionServices
{
    public class ItemBPromotion : Promotions, IPromotions
    {
        public ItemBPromotion(string item, int basePrice, string promotionDescription, int qty) : base(item, basePrice, promotionDescription, qty)
        {
        }

        public override int ApplyPromotions(int qty)
        {
            var totalPromotions = qty / TriggerQty;
            var remainder = qty % TriggerQty;
            var totalPrice = 0;

            for (var i = 0; i < totalPromotions; i++)
            {
                totalPrice += 40;
            }

            return totalPrice += remainder * BasePrice;
        }
    }
}
