using System.Text.Json.Serialization;
using Pandora.Data.Models;

namespace Pandora.Api.Components.Api.V1.Helpers
{
    public class ResourceId
    {
        public ResourceId(ResourceIdDefinition resourceId)
        {
            Name = resourceId.Name;
            Format = resourceId.Format;
        }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }
    }
}