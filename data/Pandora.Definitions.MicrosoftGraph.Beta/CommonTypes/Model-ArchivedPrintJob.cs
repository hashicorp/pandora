// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ArchivedPrintJobModel
{
    [JsonPropertyName("acquiredByPrinter")]
    public bool? AcquiredByPrinter { get; set; }

    [JsonPropertyName("acquiredDateTime")]
    public DateTime? AcquiredDateTime { get; set; }

    [JsonPropertyName("blackAndWhitePageCount")]
    public int? BlackAndWhitePageCount { get; set; }

    [JsonPropertyName("colorPageCount")]
    public int? ColorPageCount { get; set; }

    [JsonPropertyName("completionDateTime")]
    public DateTime? CompletionDateTime { get; set; }

    [JsonPropertyName("copiesPrinted")]
    public int? CopiesPrinted { get; set; }

    [JsonPropertyName("createdBy")]
    public UserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("duplexPageCount")]
    public int? DuplexPageCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pageCount")]
    public int? PageCount { get; set; }

    [JsonPropertyName("printerId")]
    public string? PrinterId { get; set; }

    [JsonPropertyName("printerName")]
    public string? PrinterName { get; set; }

    [JsonPropertyName("processingState")]
    public ArchivedPrintJobProcessingStateConstant? ProcessingState { get; set; }

    [JsonPropertyName("simplexPageCount")]
    public int? SimplexPageCount { get; set; }
}
