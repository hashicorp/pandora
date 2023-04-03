using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRulesAPIs;


internal abstract class RuleDataSourceModel
{
    [JsonPropertyName("legacyResourceId")]
    public string? LegacyResourceId { get; set; }

    [JsonPropertyName("metricNamespace")]
    public string? MetricNamespace { get; set; }

    [JsonPropertyName("odata.type")]
    [ProvidesTypeHint]
    [Required]
    public string OdataType { get; set; }

    [JsonPropertyName("resourceLocation")]
    public string? ResourceLocation { get; set; }

    [JsonPropertyName("resourceUri")]
    public string? ResourceUri { get; set; }
}
