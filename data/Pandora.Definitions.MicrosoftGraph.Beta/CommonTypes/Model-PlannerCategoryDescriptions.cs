// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerCategoryDescriptionsModel
{
    [JsonPropertyName("category1")]
    public string? Category1 { get; set; }

    [JsonPropertyName("category10")]
    public string? Category10 { get; set; }

    [JsonPropertyName("category11")]
    public string? Category11 { get; set; }

    [JsonPropertyName("category12")]
    public string? Category12 { get; set; }

    [JsonPropertyName("category13")]
    public string? Category13 { get; set; }

    [JsonPropertyName("category14")]
    public string? Category14 { get; set; }

    [JsonPropertyName("category15")]
    public string? Category15 { get; set; }

    [JsonPropertyName("category16")]
    public string? Category16 { get; set; }

    [JsonPropertyName("category17")]
    public string? Category17 { get; set; }

    [JsonPropertyName("category18")]
    public string? Category18 { get; set; }

    [JsonPropertyName("category19")]
    public string? Category19 { get; set; }

    [JsonPropertyName("category2")]
    public string? Category2 { get; set; }

    [JsonPropertyName("category20")]
    public string? Category20 { get; set; }

    [JsonPropertyName("category21")]
    public string? Category21 { get; set; }

    [JsonPropertyName("category22")]
    public string? Category22 { get; set; }

    [JsonPropertyName("category23")]
    public string? Category23 { get; set; }

    [JsonPropertyName("category24")]
    public string? Category24 { get; set; }

    [JsonPropertyName("category25")]
    public string? Category25 { get; set; }

    [JsonPropertyName("category3")]
    public string? Category3 { get; set; }

    [JsonPropertyName("category4")]
    public string? Category4 { get; set; }

    [JsonPropertyName("category5")]
    public string? Category5 { get; set; }

    [JsonPropertyName("category6")]
    public string? Category6 { get; set; }

    [JsonPropertyName("category7")]
    public string? Category7 { get; set; }

    [JsonPropertyName("category8")]
    public string? Category8 { get; set; }

    [JsonPropertyName("category9")]
    public string? Category9 { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
