using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ClusterPatchPropertiesModel
{
    [JsonPropertyName("aggregatorOrSingleRackDefinition")]
    public RackDefinitionModel? AggregatorOrSingleRackDefinition { get; set; }

    [JsonPropertyName("clusterLocation")]
    public string? ClusterLocation { get; set; }

    [JsonPropertyName("clusterServicePrincipal")]
    public ServicePrincipalInformationModel? ClusterServicePrincipal { get; set; }

    [JsonPropertyName("computeDeploymentThreshold")]
    public ValidationThresholdModel? ComputeDeploymentThreshold { get; set; }

    [JsonPropertyName("computeRackDefinitions")]
    public List<RackDefinitionModel>? ComputeRackDefinitions { get; set; }
}
