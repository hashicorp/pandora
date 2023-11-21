using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.SmartGroups;


internal class SmartGroupPropertiesModel
{
    [JsonPropertyName("alertSeverities")]
    public List<SmartGroupAggregatedPropertyModel>? AlertSeverities { get; set; }

    [JsonPropertyName("alertStates")]
    public List<SmartGroupAggregatedPropertyModel>? AlertStates { get; set; }

    [JsonPropertyName("alertsCount")]
    public int? AlertsCount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lastModifiedUserName")]
    public string? LastModifiedUserName { get; set; }

    [JsonPropertyName("monitorConditions")]
    public List<SmartGroupAggregatedPropertyModel>? MonitorConditions { get; set; }

    [JsonPropertyName("monitorServices")]
    public List<SmartGroupAggregatedPropertyModel>? MonitorServices { get; set; }

    [JsonPropertyName("nextLink")]
    public string? NextLink { get; set; }

    [JsonPropertyName("resourceGroups")]
    public List<SmartGroupAggregatedPropertyModel>? ResourceGroups { get; set; }

    [JsonPropertyName("resourceTypes")]
    public List<SmartGroupAggregatedPropertyModel>? ResourceTypes { get; set; }

    [JsonPropertyName("resources")]
    public List<SmartGroupAggregatedPropertyModel>? Resources { get; set; }

    [JsonPropertyName("severity")]
    public SeverityConstant? Severity { get; set; }

    [JsonPropertyName("smartGroupState")]
    public StateConstant? SmartGroupState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }
}
