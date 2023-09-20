// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityThreatSubmissionModel
{
    [JsonPropertyName("adminReview")]
    public SecuritySubmissionAdminReviewModel? AdminReview { get; set; }

    [JsonPropertyName("category")]
    public SecurityThreatSubmissionCategoryConstant? Category { get; set; }

    [JsonPropertyName("clientSource")]
    public SecurityThreatSubmissionClientSourceConstant? ClientSource { get; set; }

    [JsonPropertyName("contentType")]
    public SecurityThreatSubmissionContentTypeConstant? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public SecuritySubmissionUserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("result")]
    public SecuritySubmissionResultModel? Result { get; set; }

    [JsonPropertyName("source")]
    public SecurityThreatSubmissionSourceConstant? Source { get; set; }

    [JsonPropertyName("status")]
    public SecurityThreatSubmissionStatusConstant? Status { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
