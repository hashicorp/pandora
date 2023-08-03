// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AlertRecordModel
{
    [JsonPropertyName("alertImpact")]
    public AlertImpactModel? AlertImpact { get; set; }

    [JsonPropertyName("alertRuleId")]
    public string? AlertRuleId { get; set; }

    [JsonPropertyName("alertRuleTemplate")]
    public AlertRuleTemplateConstant? AlertRuleTemplate { get; set; }

    [JsonPropertyName("detectedDateTime")]
    public DateTime? DetectedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resolvedDateTime")]
    public DateTime? ResolvedDateTime { get; set; }

    [JsonPropertyName("severity")]
    public RuleSeverityTypeConstant? Severity { get; set; }

    [JsonPropertyName("status")]
    public AlertStatusTypeConstant? Status { get; set; }
}
