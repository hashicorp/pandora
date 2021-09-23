using System;
using Pandora.Data.Helpers;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class ObjectDefinition
    {
        public static Models.ObjectDefinition Map(Type input)
        {
            if (input == null)
            {
                throw new NotSupportedException("cannot map a null type");
            }

            if (Helpers.IsNativeType(input))
            {
                return new Models.ObjectDefinition
                {
                    Type = MapBuiltInObjectType(input)
                };
            }

            if (input.IsAGenericCsv())
            {
                var valueType = input.GenericCsvElement();
                var nestedItem = Map(valueType);
                return new Models.ObjectDefinition
                {
                    Type = ObjectType.Csv,
                    NestedItem = nestedItem,
                };
            }

            if (input.IsAGenericDictionary())
            {
                // at this time we only support keys which are strings, so we're only concerned with the Value Type here
                var valueType = input.GenericDictionaryValueElement();
                var nestedItem = Map(valueType);
                return new Models.ObjectDefinition
                {
                    Type = ObjectType.Dictionary,
                    NestedItem = nestedItem,
                };
            }

            if (input.IsAGenericList())
            {
                var valueType = input.GenericListElement();
                var nestedItem = Map(valueType);
                return new Models.ObjectDefinition
                {
                    Type = ObjectType.List,
                    NestedItem = nestedItem,
                };
            }

            var responseObjectName = input.Name;
            responseObjectName = RemoveSuffixFromTypeName(responseObjectName);
            return new Models.ObjectDefinition
            {
                Type = ObjectType.Reference,
                ReferenceName = responseObjectName,
            };
        }

        private static ObjectType MapBuiltInObjectType(Type input)
        {
            if (input == typeof(bool))
            {
                return ObjectType.Boolean;
            }
            if (input == typeof(float))
            {
                return ObjectType.Float;
            }
            if (input == typeof(int))
            {
                return ObjectType.Integer;
            }
            if (input == typeof(string))
            {
                return ObjectType.String;
            }

            throw new NotSupportedException($"built-in type {input.FullName} is not supported");
        }

        private static string? RemoveSuffixFromTypeName(string? input)
        {
            if (input == null)
            {
                return null;
            }

            input = input.TrimSuffix("Constant");
            input = input.TrimSuffix("Model");
            return input;
        }
    }
}