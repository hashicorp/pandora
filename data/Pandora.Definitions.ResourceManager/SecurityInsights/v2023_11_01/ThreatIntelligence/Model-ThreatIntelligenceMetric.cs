using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.ThreatIntelligence;


internal class ThreatIntelligenceMetricModel
{
    [JsonPropertyName("lastUpdatedTimeUtc")]
    public string? LastUpdatedTimeUtc { get; set; }

    [JsonPropertyName("patternTypeMetrics")]
    public List<ThreatIntelligenceMetricEntityModel>? PatternTypeMetrics { get; set; }

    [JsonPropertyName("sourceMetrics")]
    public List<ThreatIntelligenceMetricEntityModel>? SourceMetrics { get; set; }

    [JsonPropertyName("threatTypeMetrics")]
    public List<ThreatIntelligenceMetricEntityModel>? ThreatTypeMetrics { get; set; }
}
