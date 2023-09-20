// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MailAssessmentRequestModel
{
    [JsonPropertyName("category")]
    public MailAssessmentRequestCategoryConstant? Category { get; set; }

    [JsonPropertyName("contentType")]
    public MailAssessmentRequestContentTypeConstant? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("destinationRoutingReason")]
    public MailAssessmentRequestDestinationRoutingReasonConstant? DestinationRoutingReason { get; set; }

    [JsonPropertyName("expectedAssessment")]
    public MailAssessmentRequestExpectedAssessmentConstant? ExpectedAssessment { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("messageUri")]
    public string? MessageUri { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recipientEmail")]
    public string? RecipientEmail { get; set; }

    [JsonPropertyName("requestSource")]
    public MailAssessmentRequestRequestSourceConstant? RequestSource { get; set; }

    [JsonPropertyName("results")]
    public List<ThreatAssessmentResultModel>? Results { get; set; }

    [JsonPropertyName("status")]
    public MailAssessmentRequestStatusConstant? Status { get; set; }
}
