using System;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.Pandamonium.v2020_01_01.Grouping
{
    public class NestedItem
    {
        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("someDate")]
        public DateTime SomeDate { get; set; }
        
        [JsonPropertyName("someObject")]
        public object SomeObject { get; set; }
        
        [JsonPropertyName("uniqueId")]
        public string UniqueId { get; set; }
    }
}