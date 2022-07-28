using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ExpressRouteCircuits;


internal class ExpressRouteCircuitPropertiesFormatModel
{
    [JsonPropertyName("allowClassicOperations")]
    public bool? AllowClassicOperations { get; set; }

    [JsonPropertyName("authorizationKey")]
    public string? AuthorizationKey { get; set; }

    [JsonPropertyName("authorizations")]
    public List<ExpressRouteCircuitAuthorizationModel>? Authorizations { get; set; }

    [JsonPropertyName("bandwidthInGbps")]
    public float? BandwidthInGbps { get; set; }

    [JsonPropertyName("circuitProvisioningState")]
    public string? CircuitProvisioningState { get; set; }

    [JsonPropertyName("expressRoutePort")]
    public SubResourceModel? ExpressRoutePort { get; set; }

    [JsonPropertyName("gatewayManagerEtag")]
    public string? GatewayManagerEtag { get; set; }

    [JsonPropertyName("globalReachEnabled")]
    public bool? GlobalReachEnabled { get; set; }

    [JsonPropertyName("peerings")]
    public List<ExpressRouteCircuitPeeringModel>? Peerings { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("serviceKey")]
    public string? ServiceKey { get; set; }

    [JsonPropertyName("serviceProviderNotes")]
    public string? ServiceProviderNotes { get; set; }

    [JsonPropertyName("serviceProviderProperties")]
    public ExpressRouteCircuitServiceProviderPropertiesModel? ServiceProviderProperties { get; set; }

    [JsonPropertyName("serviceProviderProvisioningState")]
    public ServiceProviderProvisioningStateConstant? ServiceProviderProvisioningState { get; set; }

    [JsonPropertyName("stag")]
    public int? Stag { get; set; }
}
