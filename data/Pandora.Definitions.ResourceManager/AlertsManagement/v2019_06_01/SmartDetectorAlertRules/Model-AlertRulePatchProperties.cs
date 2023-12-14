using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_06_01.SmartDetectorAlertRules;


internal class AlertRulePatchPropertiesModel
{
    [JsonPropertyName("actionGroups")]
    public ActionGroupsInformationModel? ActionGroups { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("frequency")]
    public string? Frequency { get; set; }

    [JsonPropertyName("severity")]
    public SeverityConstant? Severity { get; set; }

    [JsonPropertyName("state")]
    public AlertRuleStateConstant? State { get; set; }

    [JsonPropertyName("throttling")]
    public ThrottlingInformationModel? Throttling { get; set; }
}
