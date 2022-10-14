using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.WorkloadNetworks;


internal class WorkloadNetworkDnsServicePropertiesModel
{
    [JsonPropertyName("defaultDnsZone")]
    public string? DefaultDnsZone { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("dnsServiceIp")]
    public string? DnsServiceIP { get; set; }

    [JsonPropertyName("fqdnZones")]
    public List<string>? FqdnZones { get; set; }

    [JsonPropertyName("logLevel")]
    public DnsServiceLogLevelEnumConstant? LogLevel { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkloadNetworkDnsServiceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("revision")]
    public int? Revision { get; set; }

    [JsonPropertyName("status")]
    public DnsServiceStatusEnumConstant? Status { get; set; }
}
