// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CustomTrainingSettingModel
{
    [JsonPropertyName("assignedTo")]
    public List<CustomTrainingSettingAssignedToConstant>? AssignedTo { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("durationInMinutes")]
    public string? DurationInMinutes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settingType")]
    public CustomTrainingSettingSettingTypeConstant? SettingType { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
