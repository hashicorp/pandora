// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IdentityGovernanceTaskProcessingResultModel
{
    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("processingStatus")]
    public IdentityGovernanceTaskProcessingResultProcessingStatusConstant? ProcessingStatus { get; set; }

    [JsonPropertyName("startedDateTime")]
    public DateTime? StartedDateTime { get; set; }

    [JsonPropertyName("subject")]
    public UserModel? Subject { get; set; }

    [JsonPropertyName("task")]
    public IdentityGovernanceTaskModel? Task { get; set; }
}
