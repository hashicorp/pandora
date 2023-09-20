// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SynchronizationStatusModel
{
    [JsonPropertyName("code")]
    public SynchronizationStatusCodeConstant? Code { get; set; }

    [JsonPropertyName("countSuccessiveCompleteFailures")]
    public int? CountSuccessiveCompleteFailures { get; set; }

    [JsonPropertyName("escrowsPruned")]
    public bool? EscrowsPruned { get; set; }

    [JsonPropertyName("lastExecution")]
    public SynchronizationTaskExecutionModel? LastExecution { get; set; }

    [JsonPropertyName("lastSuccessfulExecution")]
    public SynchronizationTaskExecutionModel? LastSuccessfulExecution { get; set; }

    [JsonPropertyName("lastSuccessfulExecutionWithExports")]
    public SynchronizationTaskExecutionModel? LastSuccessfulExecutionWithExports { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("progress")]
    public List<SynchronizationProgressModel>? Progress { get; set; }

    [JsonPropertyName("quarantine")]
    public SynchronizationQuarantineModel? Quarantine { get; set; }

    [JsonPropertyName("steadyStateFirstAchievedTime")]
    public DateTime? SteadyStateFirstAchievedTime { get; set; }

    [JsonPropertyName("steadyStateLastAchievedTime")]
    public DateTime? SteadyStateLastAchievedTime { get; set; }

    [JsonPropertyName("synchronizedEntryCountByType")]
    public List<StringKeyLongValuePairModel>? SynchronizedEntryCountByType { get; set; }

    [JsonPropertyName("troubleshootingUrl")]
    public string? TroubleshootingUrl { get; set; }
}
