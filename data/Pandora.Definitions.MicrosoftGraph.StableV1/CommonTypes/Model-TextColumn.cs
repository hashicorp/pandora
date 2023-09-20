// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TextColumnModel
{
    [JsonPropertyName("allowMultipleLines")]
    public bool? AllowMultipleLines { get; set; }

    [JsonPropertyName("appendChangesToExistingText")]
    public bool? AppendChangesToExistingText { get; set; }

    [JsonPropertyName("linesForEditing")]
    public int? LinesForEditing { get; set; }

    [JsonPropertyName("maxLength")]
    public int? MaxLength { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("textType")]
    public string? TextType { get; set; }
}
