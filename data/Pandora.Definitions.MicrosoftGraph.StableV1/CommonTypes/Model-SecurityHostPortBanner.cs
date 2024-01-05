// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityHostPortBannerModel
{
    [JsonPropertyName("banner")]
    public string? Banner { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scanProtocol")]
    public string? ScanProtocol { get; set; }

    [JsonPropertyName("timesObserved")]
    public int? TimesObserved { get; set; }
}
