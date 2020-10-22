using CheckoutKata.Models;
using System.Collections.Generic;

namespace CheckoutKata.Services.Abstractions
{
    public interface ICheckout
    {
        void AddToCheckout(string item);
        int GetTotal();
        List<CheckoutItem> GetCheckout();
    }
}
