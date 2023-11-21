using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_06_01.SmartDetectorAlertRules;


internal class AlertRulePropertiesModel
{
    [JsonPropertyName("actionGroups")]
    [Required]
    public ActionGroupsInformationModel ActionGroups { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("detector")]
    [Required]
    public DetectorModel Detector { get; set; }

    [JsonPropertyName("frequency")]
    [Required]
    public string Frequency { get; set; }

    [JsonPropertyName("scope")]
    [Required]
    public List<string> Scope { get; set; }

    [JsonPropertyName("severity")]
    [Required]
    public SeverityConstant Severity { get; set; }

    [JsonPropertyName("state")]
    [Required]
    public AlertRuleStateConstant State { get; set; }

    [JsonPropertyName("throttling")]
    public ThrottlingInformationModel? Throttling { get; set; }
}
