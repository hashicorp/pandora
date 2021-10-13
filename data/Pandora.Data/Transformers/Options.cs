using System;
using System.Collections.Generic;
using System.Reflection;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers
{
    public static class Options
    {
        public static List<OptionDefinition> Map(Type? input)
        {
            try
            {
                if (input == null)
                {
                    return new List<OptionDefinition>();
                }

                var definitions = new List<OptionDefinition>();

                var props = input.GetProperties();
                foreach (var property in props)
                {
                    var definition = new OptionDefinition
                    {
                        Name = property.Name,
                        Required = true,
                        ObjectDefinition = ObjectDefinition.Map(property.PropertyType),
                        QueryStringName = property.QueryStringName()
                    };

                    if (property.HasAttribute<OptionalAttribute>())
                    {
                        definition.Required = false;
                    }

                    definitions.Add(definition);
                }

                return definitions;
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Options Object {input.GetType().FullName}", ex);
            }
        }

        private static string QueryStringName(this MemberInfo info)
        {
            var attr = info.GetCustomAttribute<QueryStringName>();
            if (attr == null)
            {
                throw new NotSupportedException($"missing `QueryStringName` for property {info.Name}");
            }

            return attr.Name;
        }
    }
}