using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertProcessingRules;


internal class AlertProcessingRulePropertiesModel
{
    [JsonPropertyName("actions")]
    [Required]
    public List<ActionModel> Actions { get; set; }

    [JsonPropertyName("conditions")]
    public List<ConditionModel>? Conditions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("schedule")]
    public ScheduleModel? Schedule { get; set; }

    [JsonPropertyName("scopes")]
    [Required]
    public List<string> Scopes { get; set; }
}
