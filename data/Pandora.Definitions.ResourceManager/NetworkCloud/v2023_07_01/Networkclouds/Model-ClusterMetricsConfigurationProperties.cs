using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ClusterMetricsConfigurationPropertiesModel
{
    [JsonPropertyName("collectionInterval")]
    [Required]
    public int CollectionInterval { get; set; }

    [JsonPropertyName("detailedStatus")]
    public ClusterMetricsConfigurationDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("disabledMetrics")]
    public List<string>? DisabledMetrics { get; set; }

    [JsonPropertyName("enabledMetrics")]
    public List<string>? EnabledMetrics { get; set; }

    [JsonPropertyName("provisioningState")]
    public ClusterMetricsConfigurationProvisioningStateConstant? ProvisioningState { get; set; }
}
