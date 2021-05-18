using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers
{
    public static class Property
    {
        public static PropertyDefinition Map(PropertyInfo input)
        {
        //     // TODO: this needs to handle being a List of things
        //     if (input.GetType().IsAGenericList())
        //     {
        //         var nested = input.GetType().GenericListElement();
        //         // we need to iterate over the nested element
        //     }
        //     
            var jsonName = input.JsonName();
            var required = input.HasAttribute<RequiredAttribute>();
            var optional = input.HasAttribute<OptionalAttribute>();
            var forceNew = input.HasAttribute<ForceNewAttribute>();
            var isTypeHint = input.PropertyType.IsAbstract;
            var propertyType = MapPropertyType(input.PropertyType);
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
                PropertyType = propertyType,
                Validation = validation,
            };
            
            if (optional) {
                definition.Default = GetDefaultValue(input);
            }

            if (definition.PropertyType == PropertyType.List) {
                var elementDetails = GetListElementDetails(input.PropertyType);
                definition.ConstantReference = elementDetails.ConstantType;
                definition.ListElementType = elementDetails.ElementPropertyType;
                definition.ModelReference = elementDetails.ModelType;
                definition.IsTypeHint = elementDetails.IsTypeHint;
            }

            if (definition.PropertyType == PropertyType.Constant)
            {
                definition.ConstantReference = input.PropertyType.Name;
            }
            
            if (definition.PropertyType == PropertyType.DateTime)
            {
                var hasDateFormat = input.HasAttribute<DateFormatAttribute>();
                if (!hasDateFormat)
                {
                    throw new InvalidDataException($"DateTime {definition.Name} is missing a DateFormatAttribute");
                }
                var dateFormatAttr = input.GetCustomAttribute<DateFormatAttribute>();
                definition.DateFormat = dateFormatAttr.Format;
            }
            
            if (definition.PropertyType == PropertyType.Object)
            {
                // Raw Objects (which we express in C# as Object's should have no nested type)
                if (input.PropertyType != typeof(object))
                {
                    definition.ModelReference = input.PropertyType.Name;
                }
            }

            return definition;
        }

        private class ListElementDetails
        {
            public PropertyType? ElementPropertyType { get; set; }
            
            public string? ConstantType { get; set; }
            public bool IsTypeHint { get; set; }
            public string? ModelType { get; set; }
        }

        private static ListElementDetails GetListElementDetails(Type input)
        {
            var element = input.GenericListElement();
            var elementPropertyType = MapPropertyType(element);
            
            var details = new ListElementDetails();
            if (element.IsEnum)
            {
                details.ConstantType = element.Name;
                details.ElementPropertyType = PropertyType.Constant;
            }
            else
            {
                details.ModelType = element.Name;
                details.ElementPropertyType = PropertyType.Object;
                details.IsTypeHint = element.IsAbstract;
            }
            
            if (elementPropertyType == PropertyType.List)
            {
                throw new NotSupportedException("Lists cannot contain Lists");
            }

            
            return details;
        }

        private static PropertyType MapPropertyType(Type input)
        {
            if (input.IsGenericType && input.GetGenericTypeDefinition() == typeof(List<>)) {
                return PropertyType.List;
            }

            if (input.IsEnum) {
                return PropertyType.Constant;
            }
            
            // dynamic lookups can't be part of a switch statement
            // but required to handle refactoring
            var propertyType = input.ToString();
            if (propertyType == typeof(Location).FullName)
            {
                return PropertyType.Location;
            }

            if (propertyType == typeof(Tags).FullName)
            {
                return PropertyType.Tags;
            }
            
            switch (propertyType)
            {
                case "System.Boolean":
                    return PropertyType.Boolean;
                
                case "System.DateTime":
                    return PropertyType.DateTime;

                case "System.Int32":
                    return PropertyType.Integer;
                
                case "System.String":
                    return PropertyType.String;
            }

            return PropertyType.Object;
        }

        private static object? GetDefaultValue(MemberInfo input)
        {
            var optional = input.GetCustomAttribute<OptionalAttribute>();
            if (optional == null)
            {
                throw new NotSupportedException($"missing `OptionalAttribute` for property {input.Name}");
            }

            return optional.DefaultValue;
        }

        private static string JsonName(this MemberInfo info)
        {
            var jsonName = info.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (jsonName == null)
            {
                throw new NotSupportedException($"missing `JsonPropertyName` for property {info.Name}");
            }

            return jsonName.Name;
        }
    }
}