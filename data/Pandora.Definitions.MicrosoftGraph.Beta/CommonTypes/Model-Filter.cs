// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class FilterModel
{
    [JsonPropertyName("categoryFilterGroups")]
    public List<FilterGroupModel>? CategoryFilterGroups { get; set; }

    [JsonPropertyName("groups")]
    public List<FilterGroupModel>? Groups { get; set; }

    [JsonPropertyName("inputFilterGroups")]
    public List<FilterGroupModel>? InputFilterGroups { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
