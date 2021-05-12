using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Data.Models;

namespace Pandora.Api.Components.Api.V1.Helpers
{
    public class ValidationApiDefinition
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("values")]
        public List<object>? Values { get; set; }

        public static ValidationApiDefinition? Map(ValidationDefinition? input)
        {
            if (input == null)
            {
                return null;
            }
            
            return new ValidationApiDefinition
            {
                Type = MapApiValidationType(input.ValidationType),
                Values = input.Values,
            };
        }

        private static string MapApiValidationType(ValidationType input)
        {
            switch (input)
            {
                case ValidationType.Range:
                    return ApiValidationType.Range.ToString();
            }
            
            throw new NotImplementedException($"unsupported value {input.ToString()}");
        }

        private enum ApiValidationType
        {
            Range
        }
    }
}