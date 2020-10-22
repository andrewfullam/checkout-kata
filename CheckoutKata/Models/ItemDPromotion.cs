namespace CheckoutKata.Models
{
    public class ItemDPromotion : PromotionsBaseClass
    {
        public ItemDPromotion(string item) : base(item)
        {

        }

        public override int ApplyPromotion(int value, int price, int qty)
        {
            var totalPromotions = qty / 2;
            var remainder = qty % 2;
            var promotionalPrice = 0;

            for (var i = 0; i < totalPromotions; i++)
            {
                promotionalPrice += price / 100 * 75;
            }

            return promotionalPrice += remainder * price;
        }
    }
}
