using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Service;


internal abstract class ServiceResourcePropertiesModel
{
    [JsonPropertyName("correlationScheme")]
    public List<ServiceCorrelationModel>? CorrelationScheme { get; set; }

    [JsonPropertyName("defaultMoveCost")]
    public MoveCostConstant? DefaultMoveCost { get; set; }

    [JsonPropertyName("partitionDescription")]
    [Required]
    public PartitionModel PartitionDescription { get; set; }

    [JsonPropertyName("placementConstraints")]
    public string? PlacementConstraints { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("scalingPolicies")]
    public List<ScalingPolicyModel>? ScalingPolicies { get; set; }

    [JsonPropertyName("serviceKind")]
    [ProvidesTypeHint]
    [Required]
    public ServiceKindConstant ServiceKind { get; set; }

    [JsonPropertyName("serviceLoadMetrics")]
    public List<ServiceLoadMetricModel>? ServiceLoadMetrics { get; set; }

    [JsonPropertyName("servicePackageActivationMode")]
    public ServicePackageActivationModeConstant? ServicePackageActivationMode { get; set; }

    [JsonPropertyName("servicePlacementPolicies")]
    public List<ServicePlacementPolicyModel>? ServicePlacementPolicies { get; set; }

    [JsonPropertyName("serviceTypeName")]
    [Required]
    public string ServiceTypeName { get; set; }
}
