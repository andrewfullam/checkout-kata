namespace CheckoutKata.Models
{
    public class ItemBPromotion : PromotionsBaseClass
    {
        public ItemBPromotion(string item) : base(item)
        {
            Item = "3 for 40";
        }

        public override int ApplyPromotion(int value, int price, int qty)
        {
            var totalPromotions = qty / 3;
            var remainder = qty % 3;
            var promotionalPrice = 0;

            for (var i = 0; i < totalPromotions; i++)
            {
                promotionalPrice += 40;
            }

            return promotionalPrice += remainder * price;
        }
    }
}
