// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ColumnValidationModel
{
    [JsonPropertyName("defaultLanguage")]
    public string? DefaultLanguage { get; set; }

    [JsonPropertyName("descriptions")]
    public List<DisplayNameLocalizationModel>? Descriptions { get; set; }

    [JsonPropertyName("formula")]
    public string? Formula { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
