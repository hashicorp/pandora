// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class RetentionLabelSettingsModel
{
    [JsonPropertyName("behaviorDuringRetentionPeriod")]
    public RetentionLabelSettingsBehaviorDuringRetentionPeriodConstant? BehaviorDuringRetentionPeriod { get; set; }

    [JsonPropertyName("isContentUpdateAllowed")]
    public bool? IsContentUpdateAllowed { get; set; }

    [JsonPropertyName("isDeleteAllowed")]
    public bool? IsDeleteAllowed { get; set; }

    [JsonPropertyName("isLabelUpdateAllowed")]
    public bool? IsLabelUpdateAllowed { get; set; }

    [JsonPropertyName("isMetadataUpdateAllowed")]
    public bool? IsMetadataUpdateAllowed { get; set; }

    [JsonPropertyName("isRecordLocked")]
    public bool? IsRecordLocked { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
