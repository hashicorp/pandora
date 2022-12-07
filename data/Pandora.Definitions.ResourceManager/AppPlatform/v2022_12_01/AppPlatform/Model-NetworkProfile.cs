using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal class NetworkProfileModel
{
    [JsonPropertyName("appNetworkResourceGroup")]
    public string? AppNetworkResourceGroup { get; set; }

    [JsonPropertyName("appSubnetId")]
    public string? AppSubnetId { get; set; }

    [JsonPropertyName("ingressConfig")]
    public IngressConfigModel? IngressConfig { get; set; }

    [JsonPropertyName("outboundIPs")]
    public NetworkProfileOutboundIPsModel? OutboundIPs { get; set; }

    [JsonPropertyName("outboundType")]
    public string? OutboundType { get; set; }

    [JsonPropertyName("requiredTraffics")]
    public List<RequiredTrafficModel>? RequiredTraffics { get; set; }

    [JsonPropertyName("serviceCidr")]
    public string? ServiceCidr { get; set; }

    [JsonPropertyName("serviceRuntimeNetworkResourceGroup")]
    public string? ServiceRuntimeNetworkResourceGroup { get; set; }

    [JsonPropertyName("serviceRuntimeSubnetId")]
    public string? ServiceRuntimeSubnetId { get; set; }
}
