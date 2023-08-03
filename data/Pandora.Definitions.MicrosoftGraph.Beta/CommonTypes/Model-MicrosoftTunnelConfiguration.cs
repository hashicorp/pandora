// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MicrosoftTunnelConfigurationModel
{
    [JsonPropertyName("advancedSettings")]
    public List<KeyValuePairModel>? AdvancedSettings { get; set; }

    [JsonPropertyName("defaultDomainSuffix")]
    public string? DefaultDomainSuffix { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("disableUdpConnections")]
    public bool? DisableUdpConnections { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("dnsServers")]
    public List<string>? DnsServers { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastUpdateDateTime")]
    public DateTime? LastUpdateDateTime { get; set; }

    [JsonPropertyName("listenPort")]
    public int? ListenPort { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("routeExcludes")]
    public List<string>? RouteExcludes { get; set; }

    [JsonPropertyName("routeIncludes")]
    public List<string>? RouteIncludes { get; set; }

    [JsonPropertyName("routesExclude")]
    public List<string>? RoutesExclude { get; set; }

    [JsonPropertyName("routesInclude")]
    public List<string>? RoutesInclude { get; set; }

    [JsonPropertyName("splitDNS")]
    public List<string>? SplitDNS { get; set; }
}
