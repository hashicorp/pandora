using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class CloudServicesNetworkPropertiesModel
{
    [JsonPropertyName("additionalEgressEndpoints")]
    public List<EgressEndpointModel>? AdditionalEgressEndpoints { get; set; }

    [JsonPropertyName("associatedResourceIds")]
    public List<string>? AssociatedResourceIds { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("detailedStatus")]
    public CloudServicesNetworkDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("enableDefaultEgressEndpoints")]
    public CloudServicesNetworkEnableDefaultEgressEndpointsConstant? EnableDefaultEgressEndpoints { get; set; }

    [JsonPropertyName("enabledEgressEndpoints")]
    public List<EgressEndpointModel>? EnabledEgressEndpoints { get; set; }

    [JsonPropertyName("hybridAksClustersAssociatedIds")]
    public List<string>? HybridAksClustersAssociatedIds { get; set; }

    [JsonPropertyName("interfaceName")]
    public string? InterfaceName { get; set; }

    [JsonPropertyName("provisioningState")]
    public CloudServicesNetworkProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("virtualMachinesAssociatedIds")]
    public List<string>? VirtualMachinesAssociatedIds { get; set; }
}
