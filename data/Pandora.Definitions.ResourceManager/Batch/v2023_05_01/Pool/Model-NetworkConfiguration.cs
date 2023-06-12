using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_05_01.Pool;


internal class NetworkConfigurationModel
{
    [JsonPropertyName("dynamicVnetAssignmentScope")]
    public DynamicVNetAssignmentScopeConstant? DynamicVnetAssignmentScope { get; set; }

    [JsonPropertyName("enableAcceleratedNetworking")]
    public bool? EnableAcceleratedNetworking { get; set; }

    [JsonPropertyName("endpointConfiguration")]
    public PoolEndpointConfigurationModel? EndpointConfiguration { get; set; }

    [JsonPropertyName("publicIPAddressConfiguration")]
    public PublicIPAddressConfigurationModel? PublicIPAddressConfiguration { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }
}
