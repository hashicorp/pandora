// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SearchAlterationModel
{
    [JsonPropertyName("alteredHighlightedQueryString")]
    public string? AlteredHighlightedQueryString { get; set; }

    [JsonPropertyName("alteredQueryString")]
    public string? AlteredQueryString { get; set; }

    [JsonPropertyName("alteredQueryTokens")]
    public List<AlteredQueryTokenModel>? AlteredQueryTokens { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
