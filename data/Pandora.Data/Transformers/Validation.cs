using System;
using System.Reflection;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers
{
    public static class Validation
    {
        public static Models.ValidationDefinition? Map(PropertyInfo input)
        {
            var optional = input.GetCustomAttribute<FieldValidationAttribute>();
            if (optional == null)
            {
                return null;
            }

            var definition = optional.Definition();
            return new Models.ValidationDefinition
            {
                ValidationType = MapValidationType(definition.ValidationType),
                Values = definition.Values,
            };
        }
        

        private static ValidationType MapValidationType(FieldValidationType input)
        {
            switch (input)
            {
                case FieldValidationType.Range:
                    return ValidationType.Range;
                
                default:
                    throw new NotSupportedException($"unsupported validation type {input.ToString()}");
            }
        }
    }
}