using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.LoadBalancers;


internal class FlowLogPropertiesFormatModel
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("flowAnalyticsConfiguration")]
    public TrafficAnalyticsPropertiesModel? FlowAnalyticsConfiguration { get; set; }

    [JsonPropertyName("format")]
    public FlowLogFormatParametersModel? Format { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("retentionPolicy")]
    public RetentionPolicyParametersModel? RetentionPolicy { get; set; }

    [JsonPropertyName("storageId")]
    [Required]
    public string StorageId { get; set; }

    [JsonPropertyName("targetResourceGuid")]
    public string? TargetResourceGuid { get; set; }

    [JsonPropertyName("targetResourceId")]
    [Required]
    public string TargetResourceId { get; set; }
}
