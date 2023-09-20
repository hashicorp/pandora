// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RegionalFormatOverridesModel
{
    [JsonPropertyName("calendar")]
    public string? Calendar { get; set; }

    [JsonPropertyName("firstDayOfWeek")]
    public string? FirstDayOfWeek { get; set; }

    [JsonPropertyName("longDateFormat")]
    public string? LongDateFormat { get; set; }

    [JsonPropertyName("longTimeFormat")]
    public string? LongTimeFormat { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("shortDateFormat")]
    public string? ShortDateFormat { get; set; }

    [JsonPropertyName("shortTimeFormat")]
    public string? ShortTimeFormat { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }
}
