using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.AlertRules;


internal class FusionSourceSubTypeSettingModel
{
    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("severityFilters")]
    [Required]
    public FusionSubTypeSeverityFilterModel SeverityFilters { get; set; }

    [JsonPropertyName("sourceSubTypeDisplayName")]
    public string? SourceSubTypeDisplayName { get; set; }

    [JsonPropertyName("sourceSubTypeName")]
    [Required]
    public string SourceSubTypeName { get; set; }
}
