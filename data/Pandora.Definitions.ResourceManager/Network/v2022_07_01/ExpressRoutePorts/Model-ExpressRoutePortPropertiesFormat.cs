using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRoutePorts;


internal class ExpressRoutePortPropertiesFormatModel
{
    [JsonPropertyName("allocationDate")]
    public string? AllocationDate { get; set; }

    [JsonPropertyName("bandwidthInGbps")]
    public int? BandwidthInGbps { get; set; }

    [JsonPropertyName("billingType")]
    public ExpressRoutePortsBillingTypeConstant? BillingType { get; set; }

    [JsonPropertyName("circuits")]
    public List<SubResourceModel>? Circuits { get; set; }

    [JsonPropertyName("encapsulation")]
    public ExpressRoutePortsEncapsulationConstant? Encapsulation { get; set; }

    [JsonPropertyName("etherType")]
    public string? EtherType { get; set; }

    [JsonPropertyName("links")]
    public List<ExpressRouteLinkModel>? Links { get; set; }

    [JsonPropertyName("mtu")]
    public string? Mtu { get; set; }

    [JsonPropertyName("peeringLocation")]
    public string? PeeringLocation { get; set; }

    [JsonPropertyName("provisionedBandwidthInGbps")]
    public float? ProvisionedBandwidthInGbps { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }
}
