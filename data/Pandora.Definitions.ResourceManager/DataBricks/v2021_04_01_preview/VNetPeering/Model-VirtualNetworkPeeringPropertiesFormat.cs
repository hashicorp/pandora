using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.VNetPeering;


internal class VirtualNetworkPeeringPropertiesFormatModel
{
    [JsonPropertyName("allowForwardedTraffic")]
    public bool? AllowForwardedTraffic { get; set; }

    [JsonPropertyName("allowGatewayTransit")]
    public bool? AllowGatewayTransit { get; set; }

    [JsonPropertyName("allowVirtualNetworkAccess")]
    public bool? AllowVirtualNetworkAccess { get; set; }

    [JsonPropertyName("databricksAddressSpace")]
    public AddressSpaceModel? DatabricksAddressSpace { get; set; }

    [JsonPropertyName("databricksVirtualNetwork")]
    public VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkModel? DatabricksVirtualNetwork { get; set; }

    [JsonPropertyName("peeringState")]
    public PeeringStateConstant? PeeringState { get; set; }

    [JsonPropertyName("provisioningState")]
    public PeeringProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("remoteAddressSpace")]
    public AddressSpaceModel? RemoteAddressSpace { get; set; }

    [JsonPropertyName("remoteVirtualNetwork")]
    [Required]
    public VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkModel RemoteVirtualNetwork { get; set; }

    [JsonPropertyName("useRemoteGateways")]
    public bool? UseRemoteGateways { get; set; }
}
