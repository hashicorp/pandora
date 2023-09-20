// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ApprovalSettingsModel
{
    [JsonPropertyName("approvalMode")]
    public string? ApprovalMode { get; set; }

    [JsonPropertyName("approvalStages")]
    public List<UnifiedApprovalStageModel>? ApprovalStages { get; set; }

    [JsonPropertyName("isApprovalRequired")]
    public bool? IsApprovalRequired { get; set; }

    [JsonPropertyName("isApprovalRequiredForExtension")]
    public bool? IsApprovalRequiredForExtension { get; set; }

    [JsonPropertyName("isRequestorJustificationRequired")]
    public bool? IsRequestorJustificationRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
