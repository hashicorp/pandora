// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsUpdateRolloutSettingsModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("offerEndDateTimeInUTC")]
    public DateTime? OfferEndDateTimeInUTC { get; set; }

    [JsonPropertyName("offerIntervalInDays")]
    public int? OfferIntervalInDays { get; set; }

    [JsonPropertyName("offerStartDateTimeInUTC")]
    public DateTime? OfferStartDateTimeInUTC { get; set; }
}
