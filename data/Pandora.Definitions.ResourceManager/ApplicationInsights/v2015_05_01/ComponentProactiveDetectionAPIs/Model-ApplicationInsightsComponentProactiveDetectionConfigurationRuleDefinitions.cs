using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentProactiveDetectionAPIs;


internal class ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitionsModel
{
    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("DisplayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("HelpUrl")]
    public string? HelpUrl { get; set; }

    [JsonPropertyName("IsEnabledByDefault")]
    public bool? IsEnabledByDefault { get; set; }

    [JsonPropertyName("IsHidden")]
    public bool? IsHidden { get; set; }

    [JsonPropertyName("IsInPreview")]
    public bool? IsInPreview { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("SupportsEmailNotifications")]
    public bool? SupportsEmailNotifications { get; set; }
}
