using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ServersController;


internal class SqlServerApplicationModel
{
    [JsonPropertyName("clusterName")]
    public string? ClusterName { get; set; }

    [JsonPropertyName("clustered")]
    public string? Clustered { get; set; }

    [JsonPropertyName("commaSeparatedIps")]
    public string? CommaSeparatedIPs { get; set; }

    [JsonPropertyName("dnsHostName")]
    public string? DnsHostName { get; set; }

    [JsonPropertyName("edition")]
    public string? Edition { get; set; }

    [JsonPropertyName("isNamedPipeEnabled")]
    public bool? IsNamedPipeEnabled { get; set; }

    [JsonPropertyName("isTcpIpEnabled")]
    public bool? IsTcpIPEnabled { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("namedPipeName")]
    public string? NamedPipeName { get; set; }

    [JsonPropertyName("port")]
    public string? Port { get; set; }

    [JsonPropertyName("servicePack")]
    public string? ServicePack { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
