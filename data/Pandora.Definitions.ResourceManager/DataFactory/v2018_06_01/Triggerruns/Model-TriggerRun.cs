using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Triggerruns;


internal class TriggerRunModel
{
    [JsonPropertyName("dependencyStatus")]
    public Dictionary<string, object>? DependencyStatus { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("runDimension")]
    public Dictionary<string, string>? RunDimension { get; set; }

    [JsonPropertyName("status")]
    public TriggerRunStatusConstant? Status { get; set; }

    [JsonPropertyName("triggerName")]
    public string? TriggerName { get; set; }

    [JsonPropertyName("triggerRunId")]
    public string? TriggerRunId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("triggerRunTimestamp")]
    public DateTime? TriggerRunTimestamp { get; set; }

    [JsonPropertyName("triggerType")]
    public string? TriggerType { get; set; }

    [JsonPropertyName("triggeredPipelines")]
    public Dictionary<string, string>? TriggeredPipelines { get; set; }
}
