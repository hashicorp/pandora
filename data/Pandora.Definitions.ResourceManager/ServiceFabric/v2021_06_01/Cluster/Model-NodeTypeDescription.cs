using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;


internal class NodeTypeDescriptionModel
{
    [JsonPropertyName("applicationPorts")]
    public EndpointRangeDescriptionModel? ApplicationPorts { get; set; }

    [JsonPropertyName("capacities")]
    public Dictionary<string, string>? Capacities { get; set; }

    [JsonPropertyName("clientConnectionEndpointPort")]
    [Required]
    public int ClientConnectionEndpointPort { get; set; }

    [JsonPropertyName("durabilityLevel")]
    public DurabilityLevelConstant? DurabilityLevel { get; set; }

    [JsonPropertyName("ephemeralPorts")]
    public EndpointRangeDescriptionModel? EphemeralPorts { get; set; }

    [JsonPropertyName("httpGatewayEndpointPort")]
    [Required]
    public int HTTPGatewayEndpointPort { get; set; }

    [JsonPropertyName("isPrimary")]
    [Required]
    public bool IsPrimary { get; set; }

    [JsonPropertyName("isStateless")]
    public bool? IsStateless { get; set; }

    [JsonPropertyName("multipleAvailabilityZones")]
    public bool? MultipleAvailabilityZones { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("placementProperties")]
    public Dictionary<string, string>? PlacementProperties { get; set; }

    [JsonPropertyName("reverseProxyEndpointPort")]
    public int? ReverseProxyEndpointPort { get; set; }

    [JsonPropertyName("vmInstanceCount")]
    [Required]
    public int VMInstanceCount { get; set; }
}
