using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteCrossConnections;


internal class ExpressRouteCrossConnectionPropertiesModel
{
    [JsonPropertyName("bandwidthInMbps")]
    public int? BandwidthInMbps { get; set; }

    [JsonPropertyName("expressRouteCircuit")]
    public ExpressRouteCircuitReferenceModel? ExpressRouteCircuit { get; set; }

    [JsonPropertyName("peeringLocation")]
    public string? PeeringLocation { get; set; }

    [JsonPropertyName("peerings")]
    public List<ExpressRouteCrossConnectionPeeringModel>? Peerings { get; set; }

    [JsonPropertyName("primaryAzurePort")]
    public string? PrimaryAzurePort { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sTag")]
    public int? STag { get; set; }

    [JsonPropertyName("secondaryAzurePort")]
    public string? SecondaryAzurePort { get; set; }

    [JsonPropertyName("serviceProviderNotes")]
    public string? ServiceProviderNotes { get; set; }

    [JsonPropertyName("serviceProviderProvisioningState")]
    public ServiceProviderProvisioningStateConstant? ServiceProviderProvisioningState { get; set; }
}
