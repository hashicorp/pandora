// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SearchEntityModel
{
    [JsonPropertyName("acronyms")]
    public List<SearchAcronymModel>? Acronyms { get; set; }

    [JsonPropertyName("bookmarks")]
    public List<SearchBookmarkModel>? Bookmarks { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("qnas")]
    public List<SearchQnaModel>? Qnas { get; set; }
}
