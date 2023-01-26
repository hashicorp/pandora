using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;


internal class VirtualWanPropertiesModel
{
    [JsonPropertyName("allowBranchToBranchTraffic")]
    public bool? AllowBranchToBranchTraffic { get; set; }

    [JsonPropertyName("allowVnetToVnetTraffic")]
    public bool? AllowVnetToVnetTraffic { get; set; }

    [JsonPropertyName("disableVpnEncryption")]
    public bool? DisableVpnEncryption { get; set; }

    [JsonPropertyName("office365LocalBreakoutCategory")]
    public OfficeTrafficCategoryConstant? Office365LocalBreakoutCategory { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("virtualHubs")]
    public List<SubResourceModel>? VirtualHubs { get; set; }

    [JsonPropertyName("vpnSites")]
    public List<SubResourceModel>? VpnSites { get; set; }
}
