// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkDisplayScreenConfigurationModel
{
    [JsonPropertyName("backlightBrightness")]
    public int? BacklightBrightness { get; set; }

    [JsonPropertyName("backlightTimeout")]
    public string? BacklightTimeout { get; set; }

    [JsonPropertyName("isHighContrastEnabled")]
    public bool? IsHighContrastEnabled { get; set; }

    [JsonPropertyName("isScreensaverEnabled")]
    public bool? IsScreensaverEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("screensaverTimeout")]
    public string? ScreensaverTimeout { get; set; }
}
