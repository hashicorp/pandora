using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;


internal class PrivateLinkResourcePropertiesModel
{
    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("requiredMembers")]
    public List<string>? RequiredMembers { get; set; }

    [JsonPropertyName("requiredZoneNames")]
    public List<string>? RequiredZoneNames { get; set; }

    [JsonPropertyName("shareablePrivateLinkResourceTypes")]
    public List<ShareablePrivateLinkResourceTypeModel>? ShareablePrivateLinkResourceTypes { get; set; }
}
