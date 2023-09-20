// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ImageInfoModel
{
    [JsonPropertyName("addImageQuery")]
    public bool? AddImageQuery { get; set; }

    [JsonPropertyName("alternateText")]
    public string? AlternateText { get; set; }

    [JsonPropertyName("alternativeText")]
    public string? AlternativeText { get; set; }

    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
