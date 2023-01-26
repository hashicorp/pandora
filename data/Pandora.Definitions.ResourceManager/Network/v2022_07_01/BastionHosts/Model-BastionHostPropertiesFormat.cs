using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.BastionHosts;


internal class BastionHostPropertiesFormatModel
{
    [JsonPropertyName("disableCopyPaste")]
    public bool? DisableCopyPaste { get; set; }

    [JsonPropertyName("dnsName")]
    public string? DnsName { get; set; }

    [JsonPropertyName("enableFileCopy")]
    public bool? EnableFileCopy { get; set; }

    [JsonPropertyName("enableIpConnect")]
    public bool? EnableIPConnect { get; set; }

    [JsonPropertyName("enableShareableLink")]
    public bool? EnableShareableLink { get; set; }

    [JsonPropertyName("enableTunneling")]
    public bool? EnableTunneling { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<BastionHostIPConfigurationModel>? IPConfigurations { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("scaleUnits")]
    public int? ScaleUnits { get; set; }
}
