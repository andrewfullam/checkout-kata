using System.Collections.Generic;

namespace CheckoutKata.Services.Abstractions
{
    public interface IRender
    {
        string GetRenderOutputListString<T>(List<T> renderList, string header, string footer);
    }
}
