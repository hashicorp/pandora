// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IdentityGovernanceUsersProcessingSummaryModel
{
    [JsonPropertyName("failedTasks")]
    public int? FailedTasks { get; set; }

    [JsonPropertyName("failedUsers")]
    public int? FailedUsers { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("successfulUsers")]
    public int? SuccessfulUsers { get; set; }

    [JsonPropertyName("totalTasks")]
    public int? TotalTasks { get; set; }

    [JsonPropertyName("totalUsers")]
    public int? TotalUsers { get; set; }
}
