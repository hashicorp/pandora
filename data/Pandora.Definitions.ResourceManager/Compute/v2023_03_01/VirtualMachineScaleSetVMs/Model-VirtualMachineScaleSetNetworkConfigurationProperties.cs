using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineScaleSetVMs;


internal class VirtualMachineScaleSetNetworkConfigurationPropertiesModel
{
    [JsonPropertyName("deleteOption")]
    public DeleteOptionsConstant? DeleteOption { get; set; }

    [JsonPropertyName("disableTcpStateTracking")]
    public bool? DisableTcpStateTracking { get; set; }

    [JsonPropertyName("dnsSettings")]
    public VirtualMachineScaleSetNetworkConfigurationDnsSettingsModel? DnsSettings { get; set; }

    [JsonPropertyName("enableAcceleratedNetworking")]
    public bool? EnableAcceleratedNetworking { get; set; }

    [JsonPropertyName("enableFpga")]
    public bool? EnableFpga { get; set; }

    [JsonPropertyName("enableIPForwarding")]
    public bool? EnableIPForwarding { get; set; }

    [JsonPropertyName("ipConfigurations")]
    [Required]
    public List<VirtualMachineScaleSetIPConfigurationModel> IPConfigurations { get; set; }

    [JsonPropertyName("networkSecurityGroup")]
    public SubResourceModel? NetworkSecurityGroup { get; set; }

    [JsonPropertyName("primary")]
    public bool? Primary { get; set; }
}
