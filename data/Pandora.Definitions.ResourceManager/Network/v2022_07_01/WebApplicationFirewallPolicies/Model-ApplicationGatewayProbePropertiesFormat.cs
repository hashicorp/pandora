using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;


internal class ApplicationGatewayProbePropertiesFormatModel
{
    [JsonPropertyName("host")]
    public string? Host { get; set; }

    [JsonPropertyName("interval")]
    public int? Interval { get; set; }

    [JsonPropertyName("match")]
    public ApplicationGatewayProbeHealthResponseMatchModel? Match { get; set; }

    [JsonPropertyName("minServers")]
    public int? MinServers { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("pickHostNameFromBackendHttpSettings")]
    public bool? PickHostNameFromBackendHTTPSettings { get; set; }

    [JsonPropertyName("pickHostNameFromBackendSettings")]
    public bool? PickHostNameFromBackendSettings { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("protocol")]
    public ApplicationGatewayProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    [JsonPropertyName("unhealthyThreshold")]
    public int? UnhealthyThreshold { get; set; }
}
