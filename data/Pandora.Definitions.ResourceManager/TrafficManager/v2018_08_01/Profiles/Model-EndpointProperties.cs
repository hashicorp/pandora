using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles;


internal class EndpointPropertiesModel
{
    [JsonPropertyName("customHeaders")]
    public List<EndpointPropertiesCustomHeadersInlinedModel>? CustomHeaders { get; set; }

    [JsonPropertyName("endpointLocation")]
    public string? EndpointLocation { get; set; }

    [JsonPropertyName("endpointMonitorStatus")]
    public EndpointMonitorStatusConstant? EndpointMonitorStatus { get; set; }

    [JsonPropertyName("endpointStatus")]
    public EndpointStatusConstant? EndpointStatus { get; set; }

    [JsonPropertyName("geoMapping")]
    public List<string>? GeoMapping { get; set; }

    [JsonPropertyName("minChildEndpoints")]
    public int? MinChildEndpoints { get; set; }

    [JsonPropertyName("minChildEndpointsIPv4")]
    public int? MinChildEndpointsIPvFour { get; set; }

    [JsonPropertyName("minChildEndpointsIPv6")]
    public int? MinChildEndpointsIPvSix { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("subnets")]
    public List<EndpointPropertiesSubnetsInlinedModel>? Subnets { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("targetResourceId")]
    public string? TargetResourceId { get; set; }

    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
}
