using System;
using System.Collections.Generic;
using System.Reflection;

namespace CheckoutKata.Services
{
    public class RenderService<T>
    {
        public string line = "-----------------------------------------------------------------\n";

        public void RenderOutputList(List<T> renderList)
        {
            var output = line;

            foreach (var renderItem in renderList)
            {
                foreach (PropertyInfo prop in renderList.GetType().GetProperties())
                {
                    var outputLine = "";

                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    if (type == typeof(string))
                    {
                        outputLine = outputLine + prop.GetValue(prop, null);
                    }

                    output = output + outputLine + "\n";
                    output = output + "\n";
                }
            }

            output = output + line;

            Console.WriteLine(output);
        }
    }
}
