// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EmailFileAssessmentRequestModel
{
    [JsonPropertyName("category")]
    public ThreatCategoryConstant? Category { get; set; }

    [JsonPropertyName("contentData")]
    public string? ContentData { get; set; }

    [JsonPropertyName("contentType")]
    public ThreatAssessmentContentTypeConstant? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("destinationRoutingReason")]
    public MailDestinationRoutingReasonConstant? DestinationRoutingReason { get; set; }

    [JsonPropertyName("expectedAssessment")]
    public ThreatExpectedAssessmentConstant? ExpectedAssessment { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recipientEmail")]
    public string? RecipientEmail { get; set; }

    [JsonPropertyName("requestSource")]
    public ThreatAssessmentRequestSourceConstant? RequestSource { get; set; }

    [JsonPropertyName("results")]
    public List<ThreatAssessmentResultModel>? Results { get; set; }

    [JsonPropertyName("status")]
    public ThreatAssessmentStatusConstant? Status { get; set; }
}
