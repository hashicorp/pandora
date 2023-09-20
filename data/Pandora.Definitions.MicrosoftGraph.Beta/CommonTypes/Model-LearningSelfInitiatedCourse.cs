// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class LearningSelfInitiatedCourseModel
{
    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("completionPercentage")]
    public int? CompletionPercentage { get; set; }

    [JsonPropertyName("externalcourseActivityId")]
    public string? ExternalcourseActivityId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("learnerUserId")]
    public string? LearnerUserId { get; set; }

    [JsonPropertyName("learningContentId")]
    public string? LearningContentId { get; set; }

    [JsonPropertyName("learningProviderId")]
    public string? LearningProviderId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startedDateTime")]
    public DateTime? StartedDateTime { get; set; }

    [JsonPropertyName("status")]
    public LearningSelfInitiatedCourseStatusConstant? Status { get; set; }
}
