using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Data.Models;

namespace Pandora.Api.V1.Helpers
{
    public class ConstantApiDefinition
    {
        [JsonPropertyName("caseInsensitive")]
        public bool CaseInsensitive { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("values")]
        public Dictionary<string, string> Values { get; set; }
        
        public static ConstantApiDefinition Map(ConstantDefinition definition)
        {
            return new ConstantApiDefinition
            {
                CaseInsensitive = definition.CaseInsensitive,
                Type = MapConstantType(definition.Type),
                Values = definition.Values,
            };
        }

        private static string MapConstantType(ConstantType input)
        {
            switch (input)
            {
                case ConstantType.Float:
                    return "float";
                
                case ConstantType.Integer:
                    return "int";
                
                case ConstantType.String:
                    return "string";
            }

            return "unknown";
        }
    }
}