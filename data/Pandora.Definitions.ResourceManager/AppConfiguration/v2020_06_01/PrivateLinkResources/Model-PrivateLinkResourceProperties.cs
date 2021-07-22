using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources
{
    internal class PrivateLinkResourceProperties
    {
        [JsonPropertyName("groupId")]
        public string? GroupId { get; set; }

        // [JsonPropertyName("requiredMembers")]
        // public List<string>? RequiredMembers { get; set; }
        //
        // [JsonPropertyName("requiredZoneNames")]
        // public List<string>? RequiredZoneNames { get; set; }
    }
}
