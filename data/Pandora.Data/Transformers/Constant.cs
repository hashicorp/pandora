using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers
{
    public static class Constant
    {
        public static List<ConstantDefinition> FromObject(Type input)
        {
            if (!input.IsClass)
            {
                throw new NotSupportedException("expected a class");
            }
            
            var constantDefinitions = new List<ConstantDefinition>();
            foreach (var property in input.GetProperties())
            {
                if (property.PropertyType.IsEnum)
                {
                    var definition = FromEnum(property.PropertyType);
                    constantDefinitions.Add(definition);
                    continue;
                }
                
                // TODO: confirm nullable types
                // if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                // {
                //     // nullable type, check if the nested type is simple.
                //     return IsSimple((type.GetGenericArguments()[0]).GetTypeInfo());
                // }
                
                if (Helpers.IsNativeType(property.PropertyType) || Helpers.IsPandoraCustomType(property.PropertyType) || !property.PropertyType.IsClass)
                {
                    continue;
                }
                
                var innerConstants = FromObject(property.PropertyType);
                constantDefinitions.AddRange(innerConstants);
            }

            return constantDefinitions.Distinct(new ConstantComparer()).ToList();
        }
        
        public static ConstantDefinition FromEnum(Type input)
        {
            if (!input.IsEnum)
            {
                throw new NotSupportedException("expected an enum");
            }
            
            var caseInsensitive = IsCaseInsensitive(input);
            var variableType = TypeForEnum(input);
            var values = ValuesForEnum(input);

            // this enum has to have a 'description' tag for each of the values
            return new ConstantDefinition
            {
                Name = input.Name,
                CaseInsensitive = caseInsensitive,
                Type = variableType,
                Values = values,
            };
        }

        private static bool IsCaseInsensitive(Type input)
        {
            var caseInsensitiveAttribute = input.GetCustomAttribute<CaseInsensitiveDueToApiBugAttribute>();
            return caseInsensitiveAttribute != null;
        }

        private static ConstantType TypeForEnum(Type input)
        {
            var constantTypeAttribute = input.GetCustomAttribute<ConstantTypeAttribute>();
            if (constantTypeAttribute == null)
            {
                throw new NotSupportedException($"The type {input.FullName} does not contain a [ConstantType] attribute");
            }
            return MapConstantType(constantTypeAttribute.Type);
        }

        private static ConstantType MapConstantType(Pandora.Definitions.Attributes.ConstantTypeAttribute.ConstantType input)
        {
            switch (input)
            {
                case ConstantTypeAttribute.ConstantType.Float:
                    return ConstantType.Float;
                case ConstantTypeAttribute.ConstantType.Integer:
                    return ConstantType.Integer;
                case ConstantTypeAttribute.ConstantType.String:
                    return ConstantType.String;
            }

            throw new NotSupportedException($"unmapped constant type {input.ToString()}");
        }

        private static Dictionary<string, string> ValuesForEnum(Type input)
        {
            var output = new Dictionary<string, string>();
            var values = input.GetEnumValues();
            foreach (var val in values)
            {
                var enumValue = input.GetMember(val.ToString()).First();
                var description = enumValue.GetCustomAttribute<DescriptionAttribute>();
                if (description == null)
                {
                    throw new NotSupportedException(
                        $"Each value for the enum {input.Name} must implement the 'Description' attribute");
                }

                output.Add(val.ToString(), description.Description);
            }

            return output;
        }
    }
}