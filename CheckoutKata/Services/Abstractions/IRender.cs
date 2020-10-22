using System.Collections.Generic;

namespace CheckoutKata.Services.Abstractions
{
    public interface IRender<T>
    {
        static void RenderOutputList(List<T> renderList, string header, string footer);
    }
}
