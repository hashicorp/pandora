// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AssignmentFilterEvaluationSummaryModel
{
    [JsonPropertyName("assignmentFilterDisplayName")]
    public string? AssignmentFilterDisplayName { get; set; }

    [JsonPropertyName("assignmentFilterId")]
    public string? AssignmentFilterId { get; set; }

    [JsonPropertyName("assignmentFilterLastModifiedDateTime")]
    public DateTime? AssignmentFilterLastModifiedDateTime { get; set; }

    [JsonPropertyName("assignmentFilterPlatform")]
    public AssignmentFilterEvaluationSummaryAssignmentFilterPlatformConstant? AssignmentFilterPlatform { get; set; }

    [JsonPropertyName("assignmentFilterType")]
    public AssignmentFilterEvaluationSummaryAssignmentFilterTypeConstant? AssignmentFilterType { get; set; }

    [JsonPropertyName("assignmentFilterTypeAndEvaluationResults")]
    public List<AssignmentFilterTypeAndEvaluationResultModel>? AssignmentFilterTypeAndEvaluationResults { get; set; }

    [JsonPropertyName("evaluationDateTime")]
    public DateTime? EvaluationDateTime { get; set; }

    [JsonPropertyName("evaluationResult")]
    public AssignmentFilterEvaluationSummaryEvaluationResultConstant? EvaluationResult { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
