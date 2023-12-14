// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityEmailUrlThreatSubmissionModel
{
    [JsonPropertyName("adminReview")]
    public SecuritySubmissionAdminReviewModel? AdminReview { get; set; }

    [JsonPropertyName("attackSimulationInfo")]
    public SecurityAttackSimulationInfoModel? AttackSimulationInfo { get; set; }

    [JsonPropertyName("category")]
    public SecurityEmailUrlThreatSubmissionCategoryConstant? Category { get; set; }

    [JsonPropertyName("clientSource")]
    public SecurityEmailUrlThreatSubmissionClientSourceConstant? ClientSource { get; set; }

    [JsonPropertyName("contentType")]
    public SecurityEmailUrlThreatSubmissionContentTypeConstant? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public SecuritySubmissionUserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("internetMessageId")]
    public string? InternetMessageId { get; set; }

    [JsonPropertyName("messageUrl")]
    public string? MessageUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("originalCategory")]
    public SecurityEmailUrlThreatSubmissionOriginalCategoryConstant? OriginalCategory { get; set; }

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
    public SecurityEmailUrlThreatSubmissionSourceConstant? Source { get; set; }

    [JsonPropertyName("status")]
    public SecurityEmailUrlThreatSubmissionStatusConstant? Status { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("tenantAllowOrBlockListAction")]
    public SecurityTenantAllowOrBlockListActionModel? TenantAllowOrBlockListAction { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
