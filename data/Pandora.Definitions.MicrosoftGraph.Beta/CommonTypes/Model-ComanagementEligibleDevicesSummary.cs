// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ComanagementEligibleDevicesSummaryModel
{
    [JsonPropertyName("comanagedCount")]
    public int? ComanagedCount { get; set; }

    [JsonPropertyName("eligibleButNotAzureAdJoinedCount")]
    public int? EligibleButNotAzureAdJoinedCount { get; set; }

    [JsonPropertyName("eligibleCount")]
    public int? EligibleCount { get; set; }

    [JsonPropertyName("ineligibleCount")]
    public int? IneligibleCount { get; set; }

    [JsonPropertyName("needsOsUpdateCount")]
    public int? NeedsOsUpdateCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scheduledForEnrollmentCount")]
    public int? ScheduledForEnrollmentCount { get; set; }
}
