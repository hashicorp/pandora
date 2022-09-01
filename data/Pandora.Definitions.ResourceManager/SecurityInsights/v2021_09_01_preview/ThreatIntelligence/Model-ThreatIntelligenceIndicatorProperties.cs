using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.ThreatIntelligence;


internal class ThreatIntelligenceIndicatorPropertiesModel
{
    [JsonPropertyName("additionalData")]
    public Dictionary<string, object>? AdditionalData { get; set; }

    [JsonPropertyName("confidence")]
    public int? Confidence { get; set; }

    [JsonPropertyName("created")]
    public string? Created { get; set; }

    [JsonPropertyName("createdByRef")]
    public string? CreatedByRef { get; set; }

    [JsonPropertyName("defanged")]
    public bool? Defanged { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("extensions")]
    public object? Extensions { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalLastUpdatedTimeUtc")]
    public string? ExternalLastUpdatedTimeUtc { get; set; }

    [JsonPropertyName("externalReferences")]
    public List<ThreatIntelligenceExternalReferenceModel>? ExternalReferences { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("granularMarkings")]
    public List<ThreatIntelligenceGranularMarkingModelModel>? GranularMarkings { get; set; }

    [JsonPropertyName("indicatorTypes")]
    public List<string>? IndicatorTypes { get; set; }

    [JsonPropertyName("killChainPhases")]
    public List<ThreatIntelligenceKillChainPhaseModel>? KillChainPhases { get; set; }

    [JsonPropertyName("labels")]
    public List<string>? Labels { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("lastUpdatedTimeUtc")]
    public string? LastUpdatedTimeUtc { get; set; }

    [JsonPropertyName("modified")]
    public string? Modified { get; set; }

    [JsonPropertyName("objectMarkingRefs")]
    public List<string>? ObjectMarkingRefs { get; set; }

    [JsonPropertyName("parsedPattern")]
    public List<ThreatIntelligenceParsedPatternModel>? ParsedPattern { get; set; }

    [JsonPropertyName("pattern")]
    public string? Pattern { get; set; }

    [JsonPropertyName("patternType")]
    public string? PatternType { get; set; }

    [JsonPropertyName("patternVersion")]
    public string? PatternVersion { get; set; }

    [JsonPropertyName("revoked")]
    public bool? Revoked { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("threatIntelligenceTags")]
    public List<string>? ThreatIntelligenceTags { get; set; }

    [JsonPropertyName("threatTypes")]
    public List<string>? ThreatTypes { get; set; }

    [JsonPropertyName("validFrom")]
    public string? ValidFrom { get; set; }

    [JsonPropertyName("validUntil")]
    public string? ValidUntil { get; set; }
}
