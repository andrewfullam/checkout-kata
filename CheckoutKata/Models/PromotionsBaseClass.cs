namespace CheckoutKata.Models
{
    public abstract class PromotionsBaseClass
    {
        protected PromotionsBaseClass(string item)
        {
            Item = item;
        }

        public string Item { get; set; }

        public virtual int ApplyPromotion(int value, int price, int qty)
        {
            return value;
        }
    }
}
