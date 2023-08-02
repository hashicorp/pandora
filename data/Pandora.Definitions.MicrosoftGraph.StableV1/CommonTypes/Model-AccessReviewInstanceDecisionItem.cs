// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessReviewInstanceDecisionItemModel
{
    [JsonPropertyName("accessReviewId")]
    public string? AccessReviewId { get; set; }

    [JsonPropertyName("appliedBy")]
    public UserIdentityModel? AppliedBy { get; set; }

    [JsonPropertyName("appliedDateTime")]
    public DateTime? AppliedDateTime { get; set; }

    [JsonPropertyName("applyResult")]
    public string? ApplyResult { get; set; }

    [JsonPropertyName("decision")]
    public string? Decision { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("justification")]
    public string? Justification { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("principal")]
    public IdentityModel? Principal { get; set; }

    [JsonPropertyName("principalLink")]
    public string? PrincipalLink { get; set; }

    [JsonPropertyName("recommendation")]
    public string? Recommendation { get; set; }

    [JsonPropertyName("resource")]
    public AccessReviewInstanceDecisionItemResourceModel? Resource { get; set; }

    [JsonPropertyName("resourceLink")]
    public string? ResourceLink { get; set; }

    [JsonPropertyName("reviewedBy")]
    public UserIdentityModel? ReviewedBy { get; set; }

    [JsonPropertyName("reviewedDateTime")]
    public DateTime? ReviewedDateTime { get; set; }
}
