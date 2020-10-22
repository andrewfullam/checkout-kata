namespace CheckoutKata.Models
{
    public class Promotions
    {
        public string Item { get; set; }

        public virtual int ApplyPromotion(int value, int qty)
        {
            return value;
        }
    }
}
