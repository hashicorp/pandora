// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DlpPoliciesJobResultModel
{
    [JsonPropertyName("auditCorrelationId")]
    public string? AuditCorrelationId { get; set; }

    [JsonPropertyName("evaluationDateTime")]
    public DateTime? EvaluationDateTime { get; set; }

    [JsonPropertyName("matchingRules")]
    public List<MatchingDlpRuleModel>? MatchingRules { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
