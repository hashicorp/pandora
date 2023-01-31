using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;


internal class NetworkAdapterModel
{
    [JsonPropertyName("adapterId")]
    public string? AdapterId { get; set; }

    [JsonPropertyName("adapterPosition")]
    public NetworkAdapterPositionModel? AdapterPosition { get; set; }

    [JsonPropertyName("dhcpStatus")]
    public NetworkAdapterDHCPStatusConstant? DhcpStatus { get; set; }

    [JsonPropertyName("dnsServers")]
    public List<string>? DnsServers { get; set; }

    [JsonPropertyName("ipv4Configuration")]
    public IPv4ConfigModel? IPv4Configuration { get; set; }

    [JsonPropertyName("ipv6Configuration")]
    public IPv6ConfigModel? IPv6Configuration { get; set; }

    [JsonPropertyName("ipv6LinkLocalAddress")]
    public string? IPv6LinkLocalAddress { get; set; }

    [JsonPropertyName("index")]
    public int? Index { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("linkSpeed")]
    public int? LinkSpeed { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("networkAdapterName")]
    public string? NetworkAdapterName { get; set; }

    [JsonPropertyName("nodeId")]
    public string? NodeId { get; set; }

    [JsonPropertyName("rdmaStatus")]
    public NetworkAdapterRDMAStatusConstant? RdmaStatus { get; set; }

    [JsonPropertyName("status")]
    public NetworkAdapterStatusConstant? Status { get; set; }
}
