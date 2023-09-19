// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SubjectRightsRequestHistoryModel
{
    [JsonPropertyName("changedBy")]
    public IdentitySetModel? ChangedBy { get; set; }

    [JsonPropertyName("eventDateTime")]
    public DateTime? EventDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("stage")]
    public SubjectRightsRequestHistoryStageConstant? Stage { get; set; }

    [JsonPropertyName("stageStatus")]
    public SubjectRightsRequestHistoryStageStatusConstant? StageStatus { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
