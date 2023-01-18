using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggerHistories;


internal class WorkflowTriggerHistoryPropertiesModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("correlation")]
    public CorrelationModel? Correlation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("error")]
    public object? Error { get; set; }

    [JsonPropertyName("fired")]
    public bool? Fired { get; set; }

    [JsonPropertyName("inputsLink")]
    public ContentLinkModel? InputsLink { get; set; }

    [JsonPropertyName("outputsLink")]
    public ContentLinkModel? OutputsLink { get; set; }

    [JsonPropertyName("run")]
    public ResourceReferenceModel? Run { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("scheduledTime")]
    public DateTime? ScheduledTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public WorkflowStatusConstant? Status { get; set; }

    [JsonPropertyName("trackingId")]
    public string? TrackingId { get; set; }
}
