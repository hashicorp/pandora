using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Exports;


internal class ExportExecutionPropertiesModel
{
    [JsonPropertyName("error")]
    public ErrorDetailsModel? Error { get; set; }

    [JsonPropertyName("executionType")]
    public ExecutionTypeConstant? ExecutionType { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("processingEndTime")]
    public DateTime? ProcessingEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("processingStartTime")]
    public DateTime? ProcessingStartTime { get; set; }

    [JsonPropertyName("runSettings")]
    public CommonExportPropertiesModel? RunSettings { get; set; }

    [JsonPropertyName("status")]
    public ExecutionStatusConstant? Status { get; set; }

    [JsonPropertyName("submittedBy")]
    public string? SubmittedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("submittedTime")]
    public DateTime? SubmittedTime { get; set; }
}
