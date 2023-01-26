using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.DscpConfiguration;


internal class DscpConfigurationPropertiesFormatModel
{
    [JsonPropertyName("associatedNetworkInterfaces")]
    public List<NetworkInterfaceModel>? AssociatedNetworkInterfaces { get; set; }

    [JsonPropertyName("destinationIpRanges")]
    public List<QosIPRangeModel>? DestinationIPRanges { get; set; }

    [JsonPropertyName("destinationPortRanges")]
    public List<QosPortRangeModel>? DestinationPortRanges { get; set; }

    [JsonPropertyName("markings")]
    public List<int>? Markings { get; set; }

    [JsonPropertyName("protocol")]
    public ProtocolTypeConstant? Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("qosCollectionId")]
    public string? QosCollectionId { get; set; }

    [JsonPropertyName("qosDefinitionCollection")]
    public List<QosDefinitionModel>? QosDefinitionCollection { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("sourceIpRanges")]
    public List<QosIPRangeModel>? SourceIPRanges { get; set; }

    [JsonPropertyName("sourcePortRanges")]
    public List<QosPortRangeModel>? SourcePortRanges { get; set; }
}
