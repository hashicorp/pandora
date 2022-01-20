using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedCluster;


internal class NetworkSecurityRuleModel
{
    [JsonPropertyName("access")]
    [Required]
    public AccessConstant Access { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("destinationAddressPrefixes")]
    public List<string>? DestinationAddressPrefixes { get; set; }

    [JsonPropertyName("destinationPortRanges")]
    public List<string>? DestinationPortRanges { get; set; }

    [JsonPropertyName("direction")]
    [Required]
    public DirectionConstant Direction { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("priority")]
    [Required]
    public int Priority { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public NsgProtocolConstant Protocol { get; set; }

    [JsonPropertyName("sourceAddressPrefixes")]
    public List<string>? SourceAddressPrefixes { get; set; }

    [JsonPropertyName("sourcePortRanges")]
    public List<string>? SourcePortRanges { get; set; }
}
