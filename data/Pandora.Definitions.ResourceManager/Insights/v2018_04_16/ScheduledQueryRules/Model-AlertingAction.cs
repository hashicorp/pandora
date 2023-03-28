using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_04_16.ScheduledQueryRules;

[ValueForType("Microsoft.WindowsAzure.Management.Monitoring.Alerts.Models.Microsoft.AppInsights.Nexus.DataContracts.Resources.ScheduledQueryRules.AlertingAction")]
internal class AlertingActionModel : ActionModel
{
    [JsonPropertyName("aznsAction")]
    public AzNsActionGroupModel? AznsAction { get; set; }

    [JsonPropertyName("severity")]
    [Required]
    public AlertSeverityConstant Severity { get; set; }

    [JsonPropertyName("throttlingInMin")]
    public int? ThrottlingInMin { get; set; }

    [JsonPropertyName("trigger")]
    [Required]
    public TriggerConditionModel Trigger { get; set; }
}
