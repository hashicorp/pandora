// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class FileContentThreatSubmissionModel
{
    [JsonPropertyName("adminReview")]
    public SubmissionAdminReviewModel? AdminReview { get; set; }

    [JsonPropertyName("category")]
    public SubmissionCategoryConstant? Category { get; set; }

    [JsonPropertyName("clientSource")]
    public SubmissionClientSourceConstant? ClientSource { get; set; }

    [JsonPropertyName("contentType")]
    public SubmissionContentTypeConstant? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public SubmissionUserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("fileContent")]
    public string? FileContent { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("result")]
    public SubmissionResultModel? Result { get; set; }

    [JsonPropertyName("source")]
    public SubmissionSourceConstant? Source { get; set; }

    [JsonPropertyName("status")]
    public LongRunningOperationStatusConstant? Status { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
