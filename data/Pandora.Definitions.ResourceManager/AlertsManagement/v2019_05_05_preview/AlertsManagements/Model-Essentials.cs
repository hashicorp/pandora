using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;


internal class EssentialsModel
{
    [JsonPropertyName("actionStatus")]
    public ActionStatusModel? ActionStatus { get; set; }

    [JsonPropertyName("alertRule")]
    public string? AlertRule { get; set; }

    [JsonPropertyName("alertState")]
    public AlertStateConstant? AlertState { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lastModifiedUserName")]
    public string? LastModifiedUserName { get; set; }

    [JsonPropertyName("monitorCondition")]
    public MonitorConditionConstant? MonitorCondition { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("monitorConditionResolvedDateTime")]
    public DateTime? MonitorConditionResolvedDateTime { get; set; }

    [JsonPropertyName("monitorService")]
    public MonitorServiceConstant? MonitorService { get; set; }

    [JsonPropertyName("severity")]
    public SeverityConstant? Severity { get; set; }

    [JsonPropertyName("signalType")]
    public SignalTypeConstant? SignalType { get; set; }

    [JsonPropertyName("smartGroupId")]
    public string? SmartGroupId { get; set; }

    [JsonPropertyName("smartGroupingReason")]
    public string? SmartGroupingReason { get; set; }

    [JsonPropertyName("sourceCreatedId")]
    public string? SourceCreatedId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("targetResource")]
    public string? TargetResource { get; set; }

    [JsonPropertyName("targetResourceGroup")]
    public string? TargetResourceGroup { get; set; }

    [JsonPropertyName("targetResourceName")]
    public string? TargetResourceName { get; set; }

    [JsonPropertyName("targetResourceType")]
    public string? TargetResourceType { get; set; }
}
