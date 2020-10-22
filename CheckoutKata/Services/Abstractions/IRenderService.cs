using System.Collections.Generic;

namespace CheckoutKata.Services.Abstractions
{
    public interface IRenderService<T>
    {
        void RenderOutputList(List<T> renderList, string header, string footer);
    }
}
