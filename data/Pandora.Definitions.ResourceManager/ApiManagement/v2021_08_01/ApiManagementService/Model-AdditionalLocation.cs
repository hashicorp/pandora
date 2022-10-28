using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiManagementService;


internal class AdditionalLocationModel
{
    [JsonPropertyName("disableGateway")]
    public bool? DisableGateway { get; set; }

    [JsonPropertyName("gatewayRegionalUrl")]
    public string? GatewayRegionalUrl { get; set; }

    [JsonPropertyName("location")]
    [Required]
    public CustomTypes.Location Location { get; set; }

    [JsonPropertyName("platformVersion")]
    public PlatformVersionConstant? PlatformVersion { get; set; }

    [JsonPropertyName("privateIPAddresses")]
    public List<string>? PrivateIPAddresses { get; set; }

    [JsonPropertyName("publicIpAddressId")]
    public string? PublicIPAddressId { get; set; }

    [JsonPropertyName("publicIPAddresses")]
    public List<string>? PublicIPAddresses { get; set; }

    [JsonPropertyName("sku")]
    [Required]
    public ApiManagementServiceSkuPropertiesModel Sku { get; set; }

    [JsonPropertyName("virtualNetworkConfiguration")]
    public VirtualNetworkConfigurationModel? VirtualNetworkConfiguration { get; set; }

    [JsonPropertyName("zones")]
    public CustomTypes.Zones? Zones { get; set; }
}
