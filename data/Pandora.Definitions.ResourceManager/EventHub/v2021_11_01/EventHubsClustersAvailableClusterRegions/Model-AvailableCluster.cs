using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubsClustersAvailableClusterRegions;


internal class AvailableClusterModel
{
    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }
}
