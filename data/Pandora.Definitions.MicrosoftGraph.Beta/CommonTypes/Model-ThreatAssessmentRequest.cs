// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ThreatAssessmentRequestModel
{
    [JsonPropertyName("category")]
    public ThreatAssessmentRequestCategoryConstant? Category { get; set; }

    [JsonPropertyName("contentType")]
    public ThreatAssessmentRequestContentTypeConstant? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("expectedAssessment")]
    public ThreatAssessmentRequestExpectedAssessmentConstant? ExpectedAssessment { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestSource")]
    public ThreatAssessmentRequestRequestSourceConstant? RequestSource { get; set; }

    [JsonPropertyName("results")]
    public List<ThreatAssessmentResultModel>? Results { get; set; }

    [JsonPropertyName("status")]
    public ThreatAssessmentRequestStatusConstant? Status { get; set; }
}
