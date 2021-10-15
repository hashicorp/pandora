using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Pandora.Data.Transformers
{
    public static class Constant
    {
        public static List<ConstantDefinition> WithinObject(Type input)
        {
            try
            {
                var actualType = input.GetActualType(true);
                if (actualType == null)
                {
                    return new List<ConstantDefinition>();
                }
                
                if (actualType.IsEnum)
                {
                    return new List<ConstantDefinition>
                    {
                        FromEnum(input)
                    };
                }

                return WithinObject(input, new List<Type>());
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Constants WithinObject {input.FullName}", ex);
            }
        }

        private static List<ConstantDefinition> WithinObject(Type input, List<Type> knownTypes)
        {
            if (!input.IsClass)
            {
                throw new NotSupportedException("expected a class");
            }
            
            var found = new List<ConstantDefinition>();
            var types = Model.FindTypesWithinType(input, knownTypes);
            var allTypes = new List<Type>();
            allTypes.AddRange(knownTypes);
            allTypes.AddRange(types);
            
            foreach (var type in types)
            {
                var constantsWithinType = UsedByType(type);
                found.AddRange(constantsWithinType);
            }

            return found.Distinct(new ConstantComparer()).ToList();
        }
        
        private static List<ConstantDefinition> UsedByType(Type input)
        {
            var constants = new List<ConstantDefinition>();
            
            foreach (var property in input.GetProperties())
            {
                var actualType = property.PropertyType.GetActualType(true);
                if (actualType == null)
                {
                    continue;
                }
                
                if (!actualType.IsEnum)
                {
                    continue;
                }
                
                var constant = FromEnum(property.PropertyType);
                constants.Add(constant);
            }

            return constants;
        }

        public static ConstantDefinition FromEnum(Type input)
        {
            try
            {
                var actualType = input.GetActualType(true);
                if (actualType == null || !actualType.IsEnum)
                {
                    throw new NotSupportedException("expected an enum");
                }
                
                var name = actualType.Name.TrimSuffix("Constant");
                var caseInsensitive = IsCaseInsensitive(actualType);
                var variableType = TypeForEnum(actualType);
                var values = ValuesForEnum(actualType);

                // this enum has to have a 'description' tag for each of the values
                return new ConstantDefinition
                {
                    Name = name,
                    CaseInsensitive = caseInsensitive,
                    Type = variableType,
                    Values = values,
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Constant FromEnum {input.FullName}", ex);
            }
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
                // Some Enum's define `Equals` as a value, however all objects implement Equals too which apparently conflicts here
                // so filter to the member on this specific Enum
                var enumValue = input.GetMember(val.ToString()).First(m => m.DeclaringType == input);
                var description = enumValue.GetCustomAttribute<DescriptionAttribute>();
                if (description == null)
                {
                    throw new NotSupportedException(
                        $"Each value for the enum {input.Name} must implement the 'Description' attribute - but {val.ToString()} doesn't");
                }

                output.Add(val.ToString(), description.Description);
            }

            return output;
        }
    }
}
