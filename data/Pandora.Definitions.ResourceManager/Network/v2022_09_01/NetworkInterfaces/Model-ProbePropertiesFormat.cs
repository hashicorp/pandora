using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.NetworkInterfaces;


internal class ProbePropertiesFormatModel
{
    [JsonPropertyName("intervalInSeconds")]
    public int? IntervalInSeconds { get; set; }

    [JsonPropertyName("loadBalancingRules")]
    public List<SubResourceModel>? LoadBalancingRules { get; set; }

    [JsonPropertyName("numberOfProbes")]
    public int? NumberOfProbes { get; set; }

    [JsonPropertyName("port")]
    [Required]
    public int Port { get; set; }

    [JsonPropertyName("probeThreshold")]
    public int? ProbeThreshold { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public ProbeProtocolConstant Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("requestPath")]
    public string? RequestPath { get; set; }
}
