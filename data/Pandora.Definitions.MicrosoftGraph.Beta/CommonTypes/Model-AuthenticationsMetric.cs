// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AuthenticationsMetricModel
{
    [JsonPropertyName("appid")]
    public string? Appid { get; set; }

    [JsonPropertyName("attemptsCount")]
    public int? AttemptsCount { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("factDate")]
    public DateTime? FactDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("os")]
    public string? Os { get; set; }

    [JsonPropertyName("successCount")]
    public int? SuccessCount { get; set; }
}
