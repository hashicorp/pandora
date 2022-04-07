using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Replications;


internal class ReplicationPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("regionEndpointEnabled")]
    public bool? RegionEndpointEnabled { get; set; }

    [JsonPropertyName("status")]
    public StatusModel? Status { get; set; }

    [JsonPropertyName("zoneRedundancy")]
    public ZoneRedundancyConstant? ZoneRedundancy { get; set; }
}
