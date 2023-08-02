// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PersonOrGroupColumnModel
{
    [JsonPropertyName("allowMultipleSelection")]
    public bool? AllowMultipleSelection { get; set; }

    [JsonPropertyName("chooseFromType")]
    public string? ChooseFromType { get; set; }

    [JsonPropertyName("displayAs")]
    public string? DisplayAs { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
