// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkConnectionModel
{
    [JsonPropertyName("applicationName")]
    public string? ApplicationName { get; set; }

    [JsonPropertyName("destinationAddress")]
    public string? DestinationAddress { get; set; }

    [JsonPropertyName("destinationDomain")]
    public string? DestinationDomain { get; set; }

    [JsonPropertyName("destinationLocation")]
    public string? DestinationLocation { get; set; }

    [JsonPropertyName("destinationPort")]
    public string? DestinationPort { get; set; }

    [JsonPropertyName("destinationUrl")]
    public string? DestinationUrl { get; set; }

    [JsonPropertyName("direction")]
    public ConnectionDirectionConstant? Direction { get; set; }

    [JsonPropertyName("domainRegisteredDateTime")]
    public DateTime? DomainRegisteredDateTime { get; set; }

    [JsonPropertyName("localDnsName")]
    public string? LocalDnsName { get; set; }

    [JsonPropertyName("natDestinationAddress")]
    public string? NatDestinationAddress { get; set; }

    [JsonPropertyName("natDestinationPort")]
    public string? NatDestinationPort { get; set; }

    [JsonPropertyName("natSourceAddress")]
    public string? NatSourceAddress { get; set; }

    [JsonPropertyName("natSourcePort")]
    public string? NatSourcePort { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("protocol")]
    public SecurityNetworkProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("riskScore")]
    public string? RiskScore { get; set; }

    [JsonPropertyName("sourceAddress")]
    public string? SourceAddress { get; set; }

    [JsonPropertyName("sourceLocation")]
    public string? SourceLocation { get; set; }

    [JsonPropertyName("sourcePort")]
    public string? SourcePort { get; set; }

    [JsonPropertyName("status")]
    public ConnectionStatusConstant? Status { get; set; }

    [JsonPropertyName("urlParameters")]
    public string? UrlParameters { get; set; }
}
