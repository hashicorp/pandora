// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PrintUsageByPrinterModel
{
    [JsonPropertyName("blackAndWhitePageCount")]
    public int? BlackAndWhitePageCount { get; set; }

    [JsonPropertyName("colorPageCount")]
    public int? ColorPageCount { get; set; }

    [JsonPropertyName("completedBlackAndWhiteJobCount")]
    public int? CompletedBlackAndWhiteJobCount { get; set; }

    [JsonPropertyName("completedColorJobCount")]
    public int? CompletedColorJobCount { get; set; }

    [JsonPropertyName("completedJobCount")]
    public int? CompletedJobCount { get; set; }

    [JsonPropertyName("doubleSidedSheetCount")]
    public int? DoubleSidedSheetCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incompleteJobCount")]
    public int? IncompleteJobCount { get; set; }

    [JsonPropertyName("mediaSheetCount")]
    public int? MediaSheetCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pageCount")]
    public int? PageCount { get; set; }

    [JsonPropertyName("printerId")]
    public string? PrinterId { get; set; }

    [JsonPropertyName("printerName")]
    public string? PrinterName { get; set; }

    [JsonPropertyName("singleSidedSheetCount")]
    public int? SingleSidedSheetCount { get; set; }

    [JsonPropertyName("usageDate")]
    public DateTime? UsageDate { get; set; }
}
