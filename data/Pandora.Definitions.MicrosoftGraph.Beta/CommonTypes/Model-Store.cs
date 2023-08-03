// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class StoreModel
{
    [JsonPropertyName("defaultLanguageTag")]
    public string? DefaultLanguageTag { get; set; }

    [JsonPropertyName("groups")]
    public List<GroupModel>? Groups { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("languageTags")]
    public List<string>? LanguageTags { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sets")]
    public List<SetModel>? Sets { get; set; }
}
