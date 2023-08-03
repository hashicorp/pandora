// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class HostSecurityStateModel
{
    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("isAzureAdJoined")]
    public bool? IsAzureAdJoined { get; set; }

    [JsonPropertyName("isAzureAdRegistered")]
    public bool? IsAzureAdRegistered { get; set; }

    [JsonPropertyName("isHybridAzureDomainJoined")]
    public bool? IsHybridAzureDomainJoined { get; set; }

    [JsonPropertyName("netBiosName")]
    public string? NetBiosName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("os")]
    public string? Os { get; set; }

    [JsonPropertyName("privateIpAddress")]
    public string? PrivateIpAddress { get; set; }

    [JsonPropertyName("publicIpAddress")]
    public string? PublicIpAddress { get; set; }

    [JsonPropertyName("riskScore")]
    public string? RiskScore { get; set; }
}
