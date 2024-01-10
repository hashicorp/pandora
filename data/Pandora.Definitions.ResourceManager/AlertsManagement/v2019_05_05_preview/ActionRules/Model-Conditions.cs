using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.ActionRules;


internal class ConditionsModel
{
    [JsonPropertyName("alertContext")]
    public ConditionModel? AlertContext { get; set; }

    [JsonPropertyName("alertRuleId")]
    public ConditionModel? AlertRuleId { get; set; }

    [JsonPropertyName("alertRuleName")]
    public ConditionModel? AlertRuleName { get; set; }

    [JsonPropertyName("description")]
    public ConditionModel? Description { get; set; }

    [JsonPropertyName("monitorCondition")]
    public ConditionModel? MonitorCondition { get; set; }

    [JsonPropertyName("monitorService")]
    public ConditionModel? MonitorService { get; set; }

    [JsonPropertyName("severity")]
    public ConditionModel? Severity { get; set; }

    [JsonPropertyName("targetResourceType")]
    public ConditionModel? TargetResourceType { get; set; }
}
