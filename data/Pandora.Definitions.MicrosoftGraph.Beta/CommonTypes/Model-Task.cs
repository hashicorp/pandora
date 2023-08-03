// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TaskModel
{
    [JsonPropertyName("arguments")]
    public List<KeyValuePairModel>? Arguments { get; set; }

    [JsonPropertyName("category")]
    public LifecycleTaskCategoryConstant? Category { get; set; }

    [JsonPropertyName("continueOnError")]
    public bool? ContinueOnError { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("executionSequence")]
    public int? ExecutionSequence { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("taskDefinitionId")]
    public string? TaskDefinitionId { get; set; }

    [JsonPropertyName("taskProcessingResults")]
    public List<TaskProcessingResultModel>? TaskProcessingResults { get; set; }
}
