using System;
using System.Collections.Generic;
using System.Reflection;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers
{
    public static class SchemaFieldDefinition
    {
        public static TerraformSchemaFieldDefinition Map(PropertyInfo input)
        {
            var caseInsensitive = HasAttribute<CaseInsensitiveDueToApiBugAttribute>(input);
            var computed = HasAttribute<ComputedAttribute>(input);
            var hclLabel = HclLabel(input);
            var fieldType = MapFieldType(input);
            var forceNew = HasAttribute<ForceNewAttribute>(input);
            var maxItems = GetMaxItems(input);
            var minItems = GetMinItems(input);
            var optional = HasAttribute<OptionalAttribute>(input);
            var required = HasAttribute<RequiredAttribute>(input);
            var validation = Validation.Map(input);

            var definition = new TerraformSchemaFieldDefinition
            {
                CaseInsensitive = caseInsensitive,
                Computed = computed,
                HclLabel = hclLabel,
                FieldType = fieldType,
                ForceNew = forceNew,
                MaxItems = maxItems,
                MinItems = minItems,
                Name = input.Name,
                Optional = optional,
                Required = required,
                Validation = validation,
            };

            if (optional)
            {
                definition.Default = GetDefaultValue(input);
            }

            if (fieldType == TerraformFieldType.String)
            {
                // is this a constant reference?
                definition.ConstantType = GetConstantType(input);
            }

            if (fieldType == TerraformFieldType.List || fieldType == TerraformFieldType.Set)
            {
                definition.ConstantType = GetConstantType(input);
                definition.ModelType = GetModelType(input);
            }
            
            return definition;
        }

        private static TerraformFieldType MapFieldType(PropertyInfo input)
        {
            if (input.PropertyType.IsEnum)
            {
                // it's a constant reference, but we'll handle that later on
                return TerraformFieldType.String;
            }

            if (input.PropertyType == typeof(Location))
            {
                return TerraformFieldType.Location;
            }

            if (input.PropertyType == typeof(Tags))
            {
                return TerraformFieldType.Tags;
            }

            if (input.PropertyType == typeof(string))
            {
                return TerraformFieldType.String;
            }
            if (input.PropertyType == typeof(bool))
            {
                return TerraformFieldType.Boolean;
            }
            if (input.PropertyType == typeof(int))
            {
                return TerraformFieldType.Integer;
            }
            if (input.PropertyType == typeof(float))
            {
                return TerraformFieldType.Float;
            }
            
            if (input.PropertyType.IsGenericType)
            {
                // TODO: support dictionaries (which presumably map to sets)
                var typeDef = input.PropertyType.GetGenericTypeDefinition();
                if (typeDef != typeof(HashSet<>) && typeDef != typeof(List<>)) {
                    throw new NotSupportedException("Generic types have to be HashSets or Lists");
                }

                return typeDef == typeof(HashSet<>) ? TerraformFieldType.Set : TerraformFieldType.List;
            }
            
            // if this is an object, but it implements the TerraformSchemaDefinition interface it's an object
            // which we'll map to a single item list
            if (typeof(Definitions.Interfaces.TerraformSchemaDefinition).IsAssignableFrom(input.PropertyType))
            {
                return TerraformFieldType.List;
            }

            throw new NotSupportedException($"{input.Name} has an unsupported type {input.PropertyType.Name}");
        }

        private static string? GetConstantType(PropertyInfo input)
        {
            if (input.PropertyType.IsEnum)
            {
                return input.PropertyType.Name;
            }
            
            if (input.PropertyType.IsGenericType)
            {
                var typeDef = input.PropertyType.GetGenericTypeDefinition();
                if (typeDef != typeof(HashSet<>) && typeDef != typeof(List<>)) {
                    throw new NotSupportedException("Generic types have to be HashSets or Lists");
                }
                
                var innerType = input.PropertyType.GetGenericArguments()[0];
                return innerType.Name;
            }

            return null;
        }

        private static object? GetDefaultValue(MemberInfo input)
        {
            var optionalAttribute = input.GetCustomAttribute<OptionalAttribute>();
            return optionalAttribute?.DefaultValue;
        }

        private static int? GetMaxItems(PropertyInfo input)
        {
            if (typeof(Definitions.Interfaces.TerraformSchemaDefinition).IsAssignableFrom(input.PropertyType))
            {
                // a single item list
                return 1;
            }

            if (input.PropertyType.IsGenericType)
            {
                var maxItemsAttribute = input.GetCustomAttribute<MaxItemsAttribute>();
                if (maxItemsAttribute != null)
                {
                    return maxItemsAttribute.MaxItems;
                }
            }

            return null;
        }

        private static int? GetMinItems(PropertyInfo input)
        {
            if (!input.PropertyType.IsGenericType)
            {
                return null;
            }
            
            var minItemsAttribute = input.GetCustomAttribute<MinItemsAttribute>();
            if (minItemsAttribute != null)
            {
                return minItemsAttribute.MinItems;
            }

            return null;
        }

        private static string? GetModelType(PropertyInfo input)
        {
            if (!input.PropertyType.IsGenericType)
            {
                return input.PropertyType.Name;
            }

            var typeDef = input.PropertyType.GetGenericTypeDefinition();
            if (typeDef != typeof(HashSet<>) && typeDef != typeof(List<>)) {
                throw new NotSupportedException("Generic types have to be HashSets or Lists");
            }
            
            var innerType = input.PropertyType.GetGenericArguments()[0];
            return innerType.Name;
        }

        private static string HclLabel(MemberInfo input)
        {
            var hclLabel = input.GetCustomAttribute<HclLabelAttribute>();
            if (hclLabel == null)
            {
                throw new NotSupportedException($"missing `HclLabel` for property {input.Name}");
            }

            return hclLabel.Name;
        }

        private static bool HasAttribute<T>(MemberInfo info) where T : Attribute
        {
            return info.GetCustomAttribute<T>() != null;
        }
    }
}