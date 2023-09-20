// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkNetworkConfigurationModel
{
    [JsonPropertyName("defaultGateway")]
    public string? DefaultGateway { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("isDhcpEnabled")]
    public bool? IsDhcpEnabled { get; set; }

    [JsonPropertyName("isPCPortEnabled")]
    public bool? IsPCPortEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("primaryDns")]
    public string? PrimaryDns { get; set; }

    [JsonPropertyName("secondaryDns")]
    public string? SecondaryDns { get; set; }

    [JsonPropertyName("subnetMask")]
    public string? SubnetMask { get; set; }
}
