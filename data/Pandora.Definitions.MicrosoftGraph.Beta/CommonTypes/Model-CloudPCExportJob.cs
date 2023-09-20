// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCExportJobModel
{
    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("exportJobStatus")]
    public CloudPCExportJobExportJobStatusConstant? ExportJobStatus { get; set; }

    [JsonPropertyName("exportUrl")]
    public string? ExportUrl { get; set; }

    [JsonPropertyName("filter")]
    public string? Filter { get; set; }

    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reportName")]
    public CloudPCExportJobReportNameConstant? ReportName { get; set; }

    [JsonPropertyName("requestDateTime")]
    public DateTime? RequestDateTime { get; set; }

    [JsonPropertyName("select")]
    public List<string>? Select { get; set; }
}
