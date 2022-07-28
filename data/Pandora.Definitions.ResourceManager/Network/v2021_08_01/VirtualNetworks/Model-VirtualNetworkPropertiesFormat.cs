using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworks;


internal class VirtualNetworkPropertiesFormatModel
{
    [JsonPropertyName("addressSpace")]
    public AddressSpaceModel? AddressSpace { get; set; }

    [JsonPropertyName("bgpCommunities")]
    public VirtualNetworkBgpCommunitiesModel? BgpCommunities { get; set; }

    [JsonPropertyName("ddosProtectionPlan")]
    public SubResourceModel? DdosProtectionPlan { get; set; }

    [JsonPropertyName("dhcpOptions")]
    public DhcpOptionsModel? DhcpOptions { get; set; }

    [JsonPropertyName("enableDdosProtection")]
    public bool? EnableDdosProtection { get; set; }

    [JsonPropertyName("enableVmProtection")]
    public bool? EnableVmProtection { get; set; }

    [JsonPropertyName("encryption")]
    public VirtualNetworkEncryptionModel? Encryption { get; set; }

    [JsonPropertyName("flowTimeoutInMinutes")]
    public int? FlowTimeoutInMinutes { get; set; }

    [JsonPropertyName("ipAllocations")]
    public List<SubResourceModel>? IPAllocations { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("subnets")]
    public List<SubnetModel>? Subnets { get; set; }

    [JsonPropertyName("virtualNetworkPeerings")]
    public List<VirtualNetworkPeeringModel>? VirtualNetworkPeerings { get; set; }
}
