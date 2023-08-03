// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DetectedSensitiveContentModel
{
    [JsonPropertyName("classificationAttributes")]
    public List<ClassificationAttributeModel>? ClassificationAttributes { get; set; }

    [JsonPropertyName("classificationMethod")]
    public ClassificationMethodConstant? ClassificationMethod { get; set; }

    [JsonPropertyName("confidence")]
    public int? Confidence { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("matches")]
    public List<SensitiveContentLocationModel>? Matches { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recommendedConfidence")]
    public int? RecommendedConfidence { get; set; }

    [JsonPropertyName("scope")]
    public SensitiveTypeScopeConstant? Scope { get; set; }

    [JsonPropertyName("sensitiveTypeSource")]
    public SensitiveTypeSourceConstant? SensitiveTypeSource { get; set; }

    [JsonPropertyName("uniqueCount")]
    public int? UniqueCount { get; set; }
}
