// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SettingsModel
{
    [JsonPropertyName("hasGraphMailbox")]
    public bool? HasGraphMailbox { get; set; }

    [JsonPropertyName("hasLicense")]
    public bool? HasLicense { get; set; }

    [JsonPropertyName("hasOptedOut")]
    public bool? HasOptedOut { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
