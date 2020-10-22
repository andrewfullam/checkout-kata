using CheckoutKata.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CheckoutKata.Services
{
    public class Render : IRender
    {
        // Simple render string generator to output the console string. I made it generic for no other reason
        // than to show I know how to use them. Makes this reusable for other collections. Uses reflection to loop
        // through object properties
        public string GetRenderOutputListString<T>(List<T> renderList, string header, string footer)
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
                        case TypeCode.Double:
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

            return output;
        }
    }
}
