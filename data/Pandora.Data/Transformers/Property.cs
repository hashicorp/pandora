using System;
using System.Reflection;
using System.Text.Json.Serialization;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;

namespace Pandora.Data.Transformers
{
    public static class Property
    {
        public static PropertyDefinition Map(PropertyInfo input, string containingType)
        {
            try
            {
                var jsonName = input.JsonName(containingType);
                var required = input.HasAttribute<RequiredAttribute>();
                var optional = input.HasAttribute<OptionalAttribute>();
                var forceNew = input.HasAttribute<ForceNewAttribute>();
                var objectDefinition = ObjectDefinition.Map(input.PropertyType);
                var isTypeHint = input.HasAttribute<ProvidesTypeHintAttribute>();
                var validation = Validation.Map(input);

                if (required && optional)
                {
                    throw new NotSupportedException($"{input.Name} cannot be both Required and Optional");
                }

                var definition = new PropertyDefinition
                {
                    Name = input.Name,
                    JsonName = jsonName,
                    Required = required,
                    Optional = optional || !required,
                    ForceNew = forceNew,
                    IsTypeHint = isTypeHint,
                    ObjectDefinition = objectDefinition,
                    Validation = validation,
                };

                if (optional)
                {
                    definition.Default = GetDefaultValue(input, containingType);
                }

                if (input.HasAttribute<DateFormatAttribute>())
                {
                    var dateFormat = input.GetCustomAttribute<DateFormatAttribute>();
                    definition.DateFormat = dateFormat.Format;
                }

                if (input.HasAttribute<MaxItemsAttribute>())
                {
                    var attr = input.GetCustomAttribute<MaxItemsAttribute>();
                    definition.ObjectDefinition.Maximum = attr.MaxItems;
                }

                if (input.HasAttribute<MinItemsAttribute>())
                {
                    var attr = input.GetCustomAttribute<MinItemsAttribute>();
                    definition.ObjectDefinition.Minimum = attr.MinItems;
                }

                // TODO: support for Unique in time

                return definition;
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Property {input.Name}", ex);
            }
        }

        private static object? GetDefaultValue(MemberInfo input, string containingType)
        {
            var optional = input.GetCustomAttribute<OptionalAttribute>();
            if (optional == null)
            {
                throw new NotSupportedException($"missing `OptionalAttribute` for property {input.Name} in {containingType}");
            }

            return optional.DefaultValue;
        }

        private static string JsonName(this MemberInfo info, string containingType)
        {
            var jsonName = info.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (jsonName == null)
            {
                throw new NotSupportedException($"missing `JsonPropertyName` for property {info.Name} in {containingType}");
            }

            return jsonName.Name;
        }
    }
}