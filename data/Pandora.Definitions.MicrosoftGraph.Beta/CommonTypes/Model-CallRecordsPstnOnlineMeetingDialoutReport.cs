// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallRecordsPstnOnlineMeetingDialoutReportModel
{
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("destinationContext")]
    public string? DestinationContext { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("totalCallCharge")]
    public float? TotalCallCharge { get; set; }

    [JsonPropertyName("totalCallSeconds")]
    public int? TotalCallSeconds { get; set; }

    [JsonPropertyName("totalCalls")]
    public int? TotalCalls { get; set; }

    [JsonPropertyName("usageLocation")]
    public string? UsageLocation { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
