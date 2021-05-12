using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Data.Models;

namespace Pandora.Api.V1.Helpers
{
    public class ConstantApiDefinition
    {
        [JsonPropertyName("caseInsensitive")]
        public bool CaseInsensitive { get; set; }
        
        [JsonPropertyName("values")]
        public Dictionary<string, string> Values { get; set; }
        
        public static ConstantApiDefinition Map(ConstantDefinition definition)
        {
            return new ConstantApiDefinition
            {
                CaseInsensitive = definition.CaseInsensitive,
                Values = definition.Values,
            };
        }
    }
}