// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SearchHitModel
{
    [JsonPropertyName("contentSource")]
    public string? ContentSource { get; set; }

    [JsonPropertyName("hitId")]
    public string? HitId { get; set; }

    [JsonPropertyName("isCollapsed")]
    public bool? IsCollapsed { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    [JsonPropertyName("resource")]
    public EntityModel? Resource { get; set; }

    [JsonPropertyName("resultTemplateId")]
    public string? ResultTemplateId { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("_id")]
    public string? id { get; set; }

    [JsonPropertyName("_score")]
    public int? score { get; set; }

    [JsonPropertyName("_source")]
    public EntityModel? source { get; set; }

    [JsonPropertyName("_summary")]
    public string? summary { get; set; }
}
