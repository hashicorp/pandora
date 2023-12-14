// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IdentityGovernanceRunSummaryModel
{
    [JsonPropertyName("failedRuns")]
    public int? FailedRuns { get; set; }

    [JsonPropertyName("failedTasks")]
    public int? FailedTasks { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("successfulRuns")]
    public int? SuccessfulRuns { get; set; }

    [JsonPropertyName("totalRuns")]
    public int? TotalRuns { get; set; }

    [JsonPropertyName("totalTasks")]
    public int? TotalTasks { get; set; }

    [JsonPropertyName("totalUsers")]
    public int? TotalUsers { get; set; }
}
