// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessReviewInstanceModel
{
    [JsonPropertyName("contactedReviewers")]
    public List<AccessReviewReviewerModel>? ContactedReviewers { get; set; }

    [JsonPropertyName("decisions")]
    public List<AccessReviewInstanceDecisionItemModel>? Decisions { get; set; }

    [JsonPropertyName("definition")]
    public AccessReviewScheduleDefinitionModel? Definition { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("errors")]
    public List<AccessReviewErrorModel>? Errors { get; set; }

    [JsonPropertyName("fallbackReviewers")]
    public List<AccessReviewReviewerScopeModel>? FallbackReviewers { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reviewers")]
    public List<AccessReviewReviewerScopeModel>? Reviewers { get; set; }

    [JsonPropertyName("scope")]
    public AccessReviewScopeModel? Scope { get; set; }

    [JsonPropertyName("stages")]
    public List<AccessReviewStageModel>? Stages { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
