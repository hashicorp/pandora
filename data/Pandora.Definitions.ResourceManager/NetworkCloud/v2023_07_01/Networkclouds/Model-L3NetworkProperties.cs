using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class L3NetworkPropertiesModel
{
    [JsonPropertyName("associatedResourceIds")]
    public List<string>? AssociatedResourceIds { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("detailedStatus")]
    public L3NetworkDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("hybridAksClustersAssociatedIds")]
    public List<string>? HybridAksClustersAssociatedIds { get; set; }

    [JsonPropertyName("hybridAksIpamEnabled")]
    public HybridAksIPamEnabledConstant? HybridAksIPamEnabled { get; set; }

    [JsonPropertyName("hybridAksPluginType")]
    public HybridAksPluginTypeConstant? HybridAksPluginType { get; set; }

    [JsonPropertyName("ipAllocationType")]
    public IPAllocationTypeConstant? IPAllocationType { get; set; }

    [JsonPropertyName("ipv4ConnectedPrefix")]
    public string? IPv4ConnectedPrefix { get; set; }

    [JsonPropertyName("ipv6ConnectedPrefix")]
    public string? IPv6ConnectedPrefix { get; set; }

    [JsonPropertyName("interfaceName")]
    public string? InterfaceName { get; set; }

    [JsonPropertyName("l3IsolationDomainId")]
    [Required]
    public string L3IsolationDomainId { get; set; }

    [JsonPropertyName("provisioningState")]
    public L3NetworkProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("virtualMachinesAssociatedIds")]
    public List<string>? VirtualMachinesAssociatedIds { get; set; }

    [JsonPropertyName("vlan")]
    [Required]
    public int Vlan { get; set; }
}
