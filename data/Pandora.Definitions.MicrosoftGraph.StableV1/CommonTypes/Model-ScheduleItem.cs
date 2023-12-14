// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ScheduleItemModel
{
    [JsonPropertyName("end")]
    public DateTimeTimeZoneModel? End { get; set; }

    [JsonPropertyName("isPrivate")]
    public bool? IsPrivate { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("start")]
    public DateTimeTimeZoneModel? Start { get; set; }

    [JsonPropertyName("status")]
    public ScheduleItemStatusConstant? Status { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }
}
