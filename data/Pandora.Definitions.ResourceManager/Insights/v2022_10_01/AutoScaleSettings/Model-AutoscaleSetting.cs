using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_10_01.AutoScaleSettings;


internal class AutoscaleSettingModel
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("notifications")]
    public List<AutoscaleNotificationModel>? Notifications { get; set; }

    [JsonPropertyName("predictiveAutoscalePolicy")]
    public PredictiveAutoscalePolicyModel? PredictiveAutoscalePolicy { get; set; }

    [MaxItems(20)]
    [JsonPropertyName("profiles")]
    [Required]
    public List<AutoscaleProfileModel> Profiles { get; set; }

    [JsonPropertyName("targetResourceLocation")]
    public string? TargetResourceLocation { get; set; }

    [JsonPropertyName("targetResourceUri")]
    public string? TargetResourceUri { get; set; }
}
