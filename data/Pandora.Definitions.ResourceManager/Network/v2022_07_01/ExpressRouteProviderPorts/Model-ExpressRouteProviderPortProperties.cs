using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteProviderPorts;


internal class ExpressRouteProviderPortPropertiesModel
{
    [JsonPropertyName("overprovisionFactor")]
    public int? OverprovisionFactor { get; set; }

    [JsonPropertyName("peeringLocation")]
    public string? PeeringLocation { get; set; }

    [JsonPropertyName("portBandwidthInMbps")]
    public int? PortBandwidthInMbps { get; set; }

    [JsonPropertyName("portPairDescriptor")]
    public string? PortPairDescriptor { get; set; }

    [JsonPropertyName("primaryAzurePort")]
    public string? PrimaryAzurePort { get; set; }

    [JsonPropertyName("remainingBandwidthInMbps")]
    public int? RemainingBandwidthInMbps { get; set; }

    [JsonPropertyName("secondaryAzurePort")]
    public string? SecondaryAzurePort { get; set; }

    [JsonPropertyName("usedBandwidthInMbps")]
    public int? UsedBandwidthInMbps { get; set; }
}
