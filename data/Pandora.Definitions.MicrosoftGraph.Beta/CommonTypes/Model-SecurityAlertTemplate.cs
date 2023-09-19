// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityAlertTemplateModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("impactedAssets")]
    public List<SecurityImpactedAssetModel>? ImpactedAssets { get; set; }

    [JsonPropertyName("mitreTechniques")]
    public List<string>? MitreTechniques { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recommendedActions")]
    public string? RecommendedActions { get; set; }

    [JsonPropertyName("severity")]
    public SecurityAlertTemplateSeverityConstant? Severity { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
