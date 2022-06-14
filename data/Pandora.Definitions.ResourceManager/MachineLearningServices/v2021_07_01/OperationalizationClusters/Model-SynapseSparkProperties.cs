using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.OperationalizationClusters;


internal class SynapseSparkPropertiesModel
{
    [JsonPropertyName("autoPauseProperties")]
    public AutoPausePropertiesModel? AutoPauseProperties { get; set; }

    [JsonPropertyName("autoScaleProperties")]
    public AutoScalePropertiesModel? AutoScaleProperties { get; set; }

    [JsonPropertyName("nodeCount")]
    public int? NodeCount { get; set; }

    [JsonPropertyName("nodeSize")]
    public string? NodeSize { get; set; }

    [JsonPropertyName("nodeSizeFamily")]
    public string? NodeSizeFamily { get; set; }

    [JsonPropertyName("poolName")]
    public string? PoolName { get; set; }

    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("sparkVersion")]
    public string? SparkVersion { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("workspaceName")]
    public string? WorkspaceName { get; set; }
}
