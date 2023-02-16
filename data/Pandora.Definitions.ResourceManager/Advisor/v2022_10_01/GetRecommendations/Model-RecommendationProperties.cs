using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.GetRecommendations;


internal class RecommendationPropertiesModel
{
    [JsonPropertyName("actions")]
    public List<Dictionary<string, object>>? Actions { get; set; }

    [JsonPropertyName("category")]
    public CategoryConstant? Category { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("exposedMetadataProperties")]
    public Dictionary<string, object>? ExposedMetadataProperties { get; set; }

    [JsonPropertyName("extendedProperties")]
    public Dictionary<string, string>? ExtendedProperties { get; set; }

    [JsonPropertyName("impact")]
    public ImpactConstant? Impact { get; set; }

    [JsonPropertyName("impactedField")]
    public string? ImpactedField { get; set; }

    [JsonPropertyName("impactedValue")]
    public string? ImpactedValue { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("learnMoreLink")]
    public string? LearnMoreLink { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object>? Metadata { get; set; }

    [JsonPropertyName("potentialBenefits")]
    public string? PotentialBenefits { get; set; }

    [JsonPropertyName("recommendationTypeId")]
    public string? RecommendationTypeId { get; set; }

    [JsonPropertyName("remediation")]
    public Dictionary<string, object>? Remediation { get; set; }

    [JsonPropertyName("resourceMetadata")]
    public ResourceMetadataModel? ResourceMetadata { get; set; }

    [JsonPropertyName("risk")]
    public RiskConstant? Risk { get; set; }

    [JsonPropertyName("shortDescription")]
    public ShortDescriptionModel? ShortDescription { get; set; }

    [JsonPropertyName("suppressionIds")]
    public List<string>? SuppressionIds { get; set; }
}
