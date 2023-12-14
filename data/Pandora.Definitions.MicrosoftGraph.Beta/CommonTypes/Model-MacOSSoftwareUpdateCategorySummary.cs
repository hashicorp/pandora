// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOSSoftwareUpdateCategorySummaryModel
{
    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("failedUpdateCount")]
    public int? FailedUpdateCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("successfulUpdateCount")]
    public int? SuccessfulUpdateCount { get; set; }

    [JsonPropertyName("totalUpdateCount")]
    public int? TotalUpdateCount { get; set; }

    [JsonPropertyName("updateCategory")]
    public MacOSSoftwareUpdateCategorySummaryUpdateCategoryConstant? UpdateCategory { get; set; }

    [JsonPropertyName("updateStateSummaries")]
    public List<MacOSSoftwareUpdateStateSummaryModel>? UpdateStateSummaries { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
