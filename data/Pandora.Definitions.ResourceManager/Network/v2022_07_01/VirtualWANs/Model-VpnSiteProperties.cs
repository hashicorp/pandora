using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;


internal class VpnSitePropertiesModel
{
    [JsonPropertyName("addressSpace")]
    public AddressSpaceModel? AddressSpace { get; set; }

    [JsonPropertyName("bgpProperties")]
    public BgpSettingsModel? BgpProperties { get; set; }

    [JsonPropertyName("deviceProperties")]
    public DevicePropertiesModel? DeviceProperties { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("isSecuritySite")]
    public bool? IsSecuritySite { get; set; }

    [JsonPropertyName("o365Policy")]
    public O365PolicyPropertiesModel? O365Policy { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("siteKey")]
    public string? SiteKey { get; set; }

    [JsonPropertyName("virtualWan")]
    public SubResourceModel? VirtualWAN { get; set; }

    [JsonPropertyName("vpnSiteLinks")]
    public List<VpnSiteLinkModel>? VpnSiteLinks { get; set; }
}
