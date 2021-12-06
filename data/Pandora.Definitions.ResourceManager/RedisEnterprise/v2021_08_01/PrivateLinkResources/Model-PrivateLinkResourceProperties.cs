using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.PrivateLinkResources
{

    internal class PrivateLinkResourcePropertiesModel
    {
        [JsonPropertyName("groupId")]
        public string? GroupId { get; set; }

        [JsonPropertyName("requiredMembers")]
        public List<string>? RequiredMembers { get; set; }

        [JsonPropertyName("requiredZoneNames")]
        public List<string>? RequiredZoneNames { get; set; }
    }
}
