// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SearchResponseModel
{
    [JsonPropertyName("hitsContainers")]
    public List<SearchHitsContainerModel>? HitsContainers { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("queryAlterationResponse")]
    public AlterationResponseModel? QueryAlterationResponse { get; set; }

    [JsonPropertyName("resultTemplates")]
    public ResultTemplateDictionaryModel? ResultTemplates { get; set; }

    [JsonPropertyName("searchTerms")]
    public List<string>? SearchTerms { get; set; }
}
