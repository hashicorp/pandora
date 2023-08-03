// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementCachedReportConfigurationModel
{
    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("filter")]
    public string? Filter { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastRefreshDateTime")]
    public DateTime? LastRefreshDateTime { get; set; }

    [JsonPropertyName("metadata")]
    public string? Metadata { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("orderBy")]
    public List<string>? OrderBy { get; set; }

    [JsonPropertyName("reportName")]
    public string? ReportName { get; set; }

    [JsonPropertyName("select")]
    public List<string>? Select { get; set; }

    [JsonPropertyName("status")]
    public DeviceManagementReportStatusConstant? Status { get; set; }
}
