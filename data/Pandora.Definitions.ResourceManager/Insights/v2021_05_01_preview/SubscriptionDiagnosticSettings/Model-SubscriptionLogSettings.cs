using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.SubscriptionDiagnosticSettings;


internal class SubscriptionLogSettingsModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("categoryGroup")]
    public string? CategoryGroup { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }
}
