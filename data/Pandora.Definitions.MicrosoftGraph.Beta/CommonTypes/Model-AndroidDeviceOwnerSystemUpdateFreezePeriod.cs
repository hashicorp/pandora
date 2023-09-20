// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidDeviceOwnerSystemUpdateFreezePeriodModel
{
    [JsonPropertyName("endDay")]
    public int? EndDay { get; set; }

    [JsonPropertyName("endMonth")]
    public int? EndMonth { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startDay")]
    public int? StartDay { get; set; }

    [JsonPropertyName("startMonth")]
    public int? StartMonth { get; set; }
}
