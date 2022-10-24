using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.AutomationRules;


internal class IncidentPropertiesActionModel
{
    [JsonPropertyName("classification")]
    public IncidentClassificationConstant? Classification { get; set; }

    [JsonPropertyName("classificationComment")]
    public string? ClassificationComment { get; set; }

    [JsonPropertyName("classificationReason")]
    public IncidentClassificationReasonConstant? ClassificationReason { get; set; }

    [JsonPropertyName("labels")]
    public List<IncidentLabelModel>? Labels { get; set; }

    [JsonPropertyName("owner")]
    public IncidentOwnerInfoModel? Owner { get; set; }

    [JsonPropertyName("severity")]
    public IncidentSeverityConstant? Severity { get; set; }

    [JsonPropertyName("status")]
    public IncidentStatusConstant? Status { get; set; }
}
