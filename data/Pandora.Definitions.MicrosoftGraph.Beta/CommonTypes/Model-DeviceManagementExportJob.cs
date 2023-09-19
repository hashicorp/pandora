// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementExportJobModel
{
    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("filter")]
    public string? Filter { get; set; }

    [JsonPropertyName("format")]
    public DeviceManagementExportJobFormatConstant? Format { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("localizationType")]
    public DeviceManagementExportJobLocalizationTypeConstant? LocalizationType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reportName")]
    public string? ReportName { get; set; }

    [JsonPropertyName("requestDateTime")]
    public DateTime? RequestDateTime { get; set; }

    [JsonPropertyName("select")]
    public List<string>? Select { get; set; }

    [JsonPropertyName("snapshotId")]
    public string? SnapshotId { get; set; }

    [JsonPropertyName("status")]
    public DeviceManagementExportJobStatusConstant? Status { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
