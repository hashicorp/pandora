using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Service
{

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
}
