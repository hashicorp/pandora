// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCBulkRestoreModel
{
    [JsonPropertyName("actionSummary")]
    public CloudPCBulkActionSummaryModel? ActionSummary { get; set; }

    [JsonPropertyName("cloudPcIds")]
    public List<string>? CloudPCIds { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("restorePointDateTime")]
    public DateTime? RestorePointDateTime { get; set; }

    [JsonPropertyName("timeRange")]
    public CloudPCBulkRestoreTimeRangeConstant? TimeRange { get; set; }
}
