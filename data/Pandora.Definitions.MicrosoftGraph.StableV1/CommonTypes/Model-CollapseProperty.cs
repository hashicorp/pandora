// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CollapsePropertyModel
{
    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }

    [JsonPropertyName("limit")]
    public short? Limit { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
