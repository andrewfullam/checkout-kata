using CheckoutKata.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CheckoutKata.Services
{
    public class RenderService<T> : IRenderService<T>
    {
        public void RenderOutputList(List<T> renderList, string header, string footer)
        {
            var output = header;

            foreach (var renderItem in renderList)
            {
                var outputLine = "";

                foreach (PropertyInfo prop in renderItem.GetType().GetProperties())
                {

                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    switch (Type.GetTypeCode(type))
                    {
                        case TypeCode.String:
                            outputLine += prop.GetValue(renderItem, null) + " | ";
                            break;
                        case TypeCode.Int32:
                            outputLine += prop.GetValue(renderItem, null).ToString() + " | ";
                            break;
                        default:
                            break;
                    }
                }

                output += outputLine + "\n";
                output += "\n";
            }

            output += footer;

            Console.WriteLine(output);
        }
    }
}
