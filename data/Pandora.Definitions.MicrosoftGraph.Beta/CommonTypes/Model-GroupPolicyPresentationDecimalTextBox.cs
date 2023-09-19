// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GroupPolicyPresentationDecimalTextBoxModel
{
    [JsonPropertyName("defaultValue")]
    public int? DefaultValue { get; set; }

    [JsonPropertyName("definition")]
    public GroupPolicyDefinitionModel? Definition { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("maxValue")]
    public int? MaxValue { get; set; }

    [JsonPropertyName("minValue")]
    public int? MinValue { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("spin")]
    public bool? Spin { get; set; }

    [JsonPropertyName("spinStep")]
    public int? SpinStep { get; set; }
}
