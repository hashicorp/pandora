// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceComplianceUserOverviewModel
{
    [JsonPropertyName("configurationVersion")]
    public int? ConfigurationVersion { get; set; }

    [JsonPropertyName("conflictCount")]
    public int? ConflictCount { get; set; }

    [JsonPropertyName("errorCount")]
    public int? ErrorCount { get; set; }

    [JsonPropertyName("failedCount")]
    public int? FailedCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastUpdateDateTime")]
    public DateTime? LastUpdateDateTime { get; set; }

    [JsonPropertyName("notApplicableCount")]
    public int? NotApplicableCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pendingCount")]
    public int? PendingCount { get; set; }

    [JsonPropertyName("successCount")]
    public int? SuccessCount { get; set; }
}
