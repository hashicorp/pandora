// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCBulkActionSummaryModel
{
    [JsonPropertyName("failedCount")]
    public int? FailedCount { get; set; }

    [JsonPropertyName("inProgressCount")]
    public int? InProgressCount { get; set; }

    [JsonPropertyName("notSupportedCount")]
    public int? NotSupportedCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pendingCount")]
    public int? PendingCount { get; set; }

    [JsonPropertyName("successfulCount")]
    public int? SuccessfulCount { get; set; }
}
