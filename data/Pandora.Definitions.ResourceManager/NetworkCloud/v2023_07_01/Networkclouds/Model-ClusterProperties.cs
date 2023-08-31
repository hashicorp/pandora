using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ClusterPropertiesModel
{
    [JsonPropertyName("aggregatorOrSingleRackDefinition")]
    [Required]
    public RackDefinitionModel AggregatorOrSingleRackDefinition { get; set; }

    [JsonPropertyName("analyticsWorkspaceId")]
    public string? AnalyticsWorkspaceId { get; set; }

    [JsonPropertyName("availableUpgradeVersions")]
    public List<ClusterAvailableUpgradeVersionModel>? AvailableUpgradeVersions { get; set; }

    [JsonPropertyName("clusterCapacity")]
    public ClusterCapacityModel? ClusterCapacity { get; set; }

    [JsonPropertyName("clusterConnectionStatus")]
    public ClusterConnectionStatusConstant? ClusterConnectionStatus { get; set; }

    [JsonPropertyName("clusterExtendedLocation")]
    public ExtendedLocationModel? ClusterExtendedLocation { get; set; }

    [JsonPropertyName("clusterLocation")]
    public string? ClusterLocation { get; set; }

    [JsonPropertyName("clusterManagerConnectionStatus")]
    public ClusterManagerConnectionStatusConstant? ClusterManagerConnectionStatus { get; set; }

    [JsonPropertyName("clusterManagerId")]
    public string? ClusterManagerId { get; set; }

    [JsonPropertyName("clusterServicePrincipal")]
    public ServicePrincipalInformationModel? ClusterServicePrincipal { get; set; }

    [JsonPropertyName("clusterType")]
    [Required]
    public ClusterTypeConstant ClusterType { get; set; }

    [JsonPropertyName("clusterVersion")]
    [Required]
    public string ClusterVersion { get; set; }

    [JsonPropertyName("computeDeploymentThreshold")]
    public ValidationThresholdModel? ComputeDeploymentThreshold { get; set; }

    [JsonPropertyName("computeRackDefinitions")]
    public List<RackDefinitionModel>? ComputeRackDefinitions { get; set; }

    [JsonPropertyName("detailedStatus")]
    public ClusterDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("hybridAksExtendedLocation")]
    public ExtendedLocationModel? HybridAksExtendedLocation { get; set; }

    [JsonPropertyName("managedResourceGroupConfiguration")]
    public ManagedResourceGroupConfigurationModel? ManagedResourceGroupConfiguration { get; set; }

    [JsonPropertyName("manualActionCount")]
    public int? ManualActionCount { get; set; }

    [JsonPropertyName("networkFabricId")]
    [Required]
    public string NetworkFabricId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ClusterProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("supportExpiryDate")]
    public string? SupportExpiryDate { get; set; }

    [JsonPropertyName("workloadResourceIds")]
    public List<string>? WorkloadResourceIds { get; set; }
}
