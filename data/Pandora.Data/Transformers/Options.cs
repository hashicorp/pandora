using System;
using System.Collections.Generic;
using System.Reflection;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers
{
    public static class Options
    {
        public static List<OptionDefinition> Map(object input)
        {
            try
            {
                if (input == null)
                {
                    return new List<OptionDefinition>();
                }

                var definitions = new List<OptionDefinition>();

                var props = input.GetType().GetProperties();
                foreach (var property in props)
                {
                    var definition = new OptionDefinition
                    {
                        Name = property.Name,
                        Required = true,
                        Type = MapOptionDefinitionType(property.PropertyType),
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

        private static OptionDefinitionType MapOptionDefinitionType(Type propertyType)
        {
            switch (propertyType.ToString())
            {
                case "System.Boolean":
                    return OptionDefinitionType.Boolean;

                case "System.Int32":
                    return OptionDefinitionType.Integer;

                case "System.String":
                    return OptionDefinitionType.String;
            }

            throw new NotSupportedException($"{propertyType} is not supported for options");
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