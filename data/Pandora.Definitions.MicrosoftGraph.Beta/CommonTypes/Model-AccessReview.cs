// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessReviewModel
{
    [JsonPropertyName("businessFlowTemplateId")]
    public string? BusinessFlowTemplateId { get; set; }

    [JsonPropertyName("createdBy")]
    public UserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("decisions")]
    public List<AccessReviewDecisionModel>? Decisions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("instances")]
    public List<AccessReviewModel>? Instances { get; set; }

    [JsonPropertyName("myDecisions")]
    public List<AccessReviewDecisionModel>? MyDecisions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reviewedEntity")]
    public IdentityModel? ReviewedEntity { get; set; }

    [JsonPropertyName("reviewerType")]
    public string? ReviewerType { get; set; }

    [JsonPropertyName("reviewers")]
    public List<AccessReviewReviewerModel>? Reviewers { get; set; }

    [JsonPropertyName("settings")]
    public AccessReviewSettingsModel? Settings { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
