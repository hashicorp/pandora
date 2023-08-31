using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class KubernetesClusterPropertiesModel
{
    [JsonPropertyName("aadConfiguration")]
    public AadConfigurationModel? AadConfiguration { get; set; }

    [JsonPropertyName("administratorConfiguration")]
    public AdministratorConfigurationModel? AdministratorConfiguration { get; set; }

    [JsonPropertyName("attachedNetworkIds")]
    public List<string>? AttachedNetworkIds { get; set; }

    [JsonPropertyName("availableUpgrades")]
    public List<AvailableUpgradeModel>? AvailableUpgrades { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("connectedClusterId")]
    public string? ConnectedClusterId { get; set; }

    [JsonPropertyName("controlPlaneKubernetesVersion")]
    public string? ControlPlaneKubernetesVersion { get; set; }

    [JsonPropertyName("controlPlaneNodeConfiguration")]
    [Required]
    public ControlPlaneNodeConfigurationModel ControlPlaneNodeConfiguration { get; set; }

    [JsonPropertyName("detailedStatus")]
    public KubernetesClusterDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("featureStatuses")]
    public List<FeatureStatusModel>? FeatureStatuses { get; set; }

    [MinItems(1)]
    [JsonPropertyName("initialAgentPoolConfigurations")]
    [Required]
    public List<InitialAgentPoolConfigurationModel> InitialAgentPoolConfigurations { get; set; }

    [JsonPropertyName("kubernetesVersion")]
    [Required]
    public string KubernetesVersion { get; set; }

    [JsonPropertyName("managedResourceGroupConfiguration")]
    public ManagedResourceGroupConfigurationModel? ManagedResourceGroupConfiguration { get; set; }

    [JsonPropertyName("networkConfiguration")]
    [Required]
    public NetworkConfigurationModel NetworkConfiguration { get; set; }

    [JsonPropertyName("nodes")]
    public List<KubernetesClusterNodeModel>? Nodes { get; set; }

    [JsonPropertyName("provisioningState")]
    public KubernetesClusterProvisioningStateConstant? ProvisioningState { get; set; }
}
