using System;
using System.Text.Json.Serialization;
using Pandora.Data.Models;

namespace Pandora.Api.V1.Helpers
{
    public static class ApiObjectDefinitionMapper
    {
        internal static ApiObjectDefinition? Map(ObjectDefinition? input)
        {
            if (input == null)
            {
                return null;
            }

            var definition = new ApiObjectDefinition
            {
                ReferenceName = input.ReferenceName,
                Type = MapApiObjectType(input.Type)
            };
            if (input.NestedItem != null)
            {
                definition.NestedItem = Map(input.NestedItem);
            }
            return definition;
        }

        private static string MapApiObjectType(ObjectType input)
        {
            switch (input)
            {
                // TODO: support for Csv/DateTime/RawFile/RawObject
                case ObjectType.Boolean:
                    return ApiObjectType.Boolean.ToString();
                case ObjectType.Dictionary:
                    return ApiObjectType.Dictionary.ToString();
                case ObjectType.Float:
                    return ApiObjectType.Float.ToString();
                case ObjectType.Integer:
                    return ApiObjectType.Integer.ToString();
                case ObjectType.List:
                    return ApiObjectType.List.ToString();
                case ObjectType.Reference:
                    return ApiObjectType.Reference.ToString();
                case ObjectType.String:
                    return ApiObjectType.String.ToString();
            }

            throw new NotSupportedException($"Unsupported ObjectType {input}");
        }
    }

    public class ApiObjectDefinition
    {
        [JsonPropertyName("nestedItem")]
        public ApiObjectDefinition? NestedItem { get; set; }

        [JsonPropertyName("referenceName")]
        public string? ReferenceName { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }

    public enum ApiObjectType
    {
        Boolean,
        Dictionary,
        Integer,
        Float,
        List,
        Reference,
        String
    }
}