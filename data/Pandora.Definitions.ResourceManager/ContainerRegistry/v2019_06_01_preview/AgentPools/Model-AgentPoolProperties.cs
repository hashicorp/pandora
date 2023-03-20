using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.AgentPools;


internal class AgentPoolPropertiesModel
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("os")]
    public OSConstant? Os { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }

    [JsonPropertyName("virtualNetworkSubnetResourceId")]
    public string? VirtualNetworkSubnetResourceId { get; set; }
}
