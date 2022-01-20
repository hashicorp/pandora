using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.PrivateLinkResource;


internal class PrivateLinkResourcePropertiesModel
{
    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("requiredMembers")]
    public List<string>? RequiredMembers { get; set; }

    [JsonPropertyName("requiredZoneNames")]
    public List<string>? RequiredZoneNames { get; set; }
}
