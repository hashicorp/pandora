// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TermModel
{
    [JsonPropertyName("children")]
    public List<TermModel>? Children { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("descriptions")]
    public List<LocalizedDescriptionModel>? Descriptions { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("labels")]
    public List<LocalizedLabelModel>? Labels { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("properties")]
    public List<KeyValueModel>? Properties { get; set; }

    [JsonPropertyName("relations")]
    public List<RelationModel>? Relations { get; set; }

    [JsonPropertyName("set")]
    public SetModel? Set { get; set; }
}
