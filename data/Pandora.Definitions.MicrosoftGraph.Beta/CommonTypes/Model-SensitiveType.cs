// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SensitiveTypeModel
{
    [JsonPropertyName("classificationMethod")]
    public ClassificationMethodConstant? ClassificationMethod { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("publisherName")]
    public string? PublisherName { get; set; }

    [JsonPropertyName("rulePackageId")]
    public string? RulePackageId { get; set; }

    [JsonPropertyName("rulePackageType")]
    public string? RulePackageType { get; set; }

    [JsonPropertyName("scope")]
    public SensitiveTypeScopeConstant? Scope { get; set; }

    [JsonPropertyName("sensitiveTypeSource")]
    public SensitiveTypeSourceConstant? SensitiveTypeSource { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}
