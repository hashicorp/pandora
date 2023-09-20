// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityFileUrlThreatSubmissionModel
{
    [JsonPropertyName("adminReview")]
    public SecuritySubmissionAdminReviewModel? AdminReview { get; set; }

    [JsonPropertyName("category")]
    public SecurityFileUrlThreatSubmissionCategoryConstant? Category { get; set; }

    [JsonPropertyName("clientSource")]
    public SecurityFileUrlThreatSubmissionClientSourceConstant? ClientSource { get; set; }

    [JsonPropertyName("contentType")]
    public SecurityFileUrlThreatSubmissionContentTypeConstant? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public SecuritySubmissionUserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("fileUrl")]
    public string? FileUrl { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("result")]
    public SecuritySubmissionResultModel? Result { get; set; }

    [JsonPropertyName("source")]
    public SecurityFileUrlThreatSubmissionSourceConstant? Source { get; set; }

    [JsonPropertyName("status")]
    public SecurityFileUrlThreatSubmissionStatusConstant? Status { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
