using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ClusterManagerPropertiesModel
{
    [JsonPropertyName("analyticsWorkspaceId")]
    public string? AnalyticsWorkspaceId { get; set; }

    [JsonPropertyName("availabilityZones")]
    public CustomTypes.Zones? AvailabilityZones { get; set; }

    [JsonPropertyName("clusterVersions")]
    public List<ClusterAvailableVersionModel>? ClusterVersions { get; set; }

    [JsonPropertyName("detailedStatus")]
    public ClusterManagerDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("fabricControllerId")]
    [Required]
    public string FabricControllerId { get; set; }

    [JsonPropertyName("managedResourceGroupConfiguration")]
    public ManagedResourceGroupConfigurationModel? ManagedResourceGroupConfiguration { get; set; }

    [JsonPropertyName("managerExtendedLocation")]
    public ExtendedLocationModel? ManagerExtendedLocation { get; set; }

    [JsonPropertyName("provisioningState")]
    public ClusterManagerProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VMSize { get; set; }
}
