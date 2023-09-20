// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityEmailContentThreatSubmissionModel
{
    [JsonPropertyName("adminReview")]
    public SecuritySubmissionAdminReviewModel? AdminReview { get; set; }

    [JsonPropertyName("attackSimulationInfo")]
    public SecurityAttackSimulationInfoModel? AttackSimulationInfo { get; set; }

    [JsonPropertyName("category")]
    public SecurityEmailContentThreatSubmissionCategoryConstant? Category { get; set; }

    [JsonPropertyName("clientSource")]
    public SecurityEmailContentThreatSubmissionClientSourceConstant? ClientSource { get; set; }

    [JsonPropertyName("contentType")]
    public SecurityEmailContentThreatSubmissionContentTypeConstant? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public SecuritySubmissionUserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("fileContent")]
    public string? FileContent { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("internetMessageId")]
    public string? InternetMessageId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("originalCategory")]
    public SecurityEmailContentThreatSubmissionOriginalCategoryConstant? OriginalCategory { get; set; }

    [JsonPropertyName("receivedDateTime")]
    public DateTime? ReceivedDateTime { get; set; }

    [JsonPropertyName("recipientEmailAddress")]
    public string? RecipientEmailAddress { get; set; }

    [JsonPropertyName("result")]
    public SecuritySubmissionResultModel? Result { get; set; }

    [JsonPropertyName("sender")]
    public string? Sender { get; set; }

    [JsonPropertyName("senderIP")]
    public string? SenderIP { get; set; }

    [JsonPropertyName("source")]
    public SecurityEmailContentThreatSubmissionSourceConstant? Source { get; set; }

    [JsonPropertyName("status")]
    public SecurityEmailContentThreatSubmissionStatusConstant? Status { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("tenantAllowOrBlockListAction")]
    public SecurityTenantAllowOrBlockListActionModel? TenantAllowOrBlockListAction { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
