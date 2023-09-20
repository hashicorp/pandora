// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

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
}
