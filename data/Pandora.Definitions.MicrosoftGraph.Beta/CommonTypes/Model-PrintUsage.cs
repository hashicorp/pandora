// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrintUsageModel
{
    [JsonPropertyName("blackAndWhitePageCount")]
    public long? BlackAndWhitePageCount { get; set; }

    [JsonPropertyName("colorPageCount")]
    public long? ColorPageCount { get; set; }

    [JsonPropertyName("completedBlackAndWhiteJobCount")]
    public long? CompletedBlackAndWhiteJobCount { get; set; }

    [JsonPropertyName("completedColorJobCount")]
    public long? CompletedColorJobCount { get; set; }

    [JsonPropertyName("completedJobCount")]
    public long? CompletedJobCount { get; set; }

    [JsonPropertyName("doubleSidedSheetCount")]
    public long? DoubleSidedSheetCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incompleteJobCount")]
    public long? IncompleteJobCount { get; set; }

    [JsonPropertyName("mediaSheetCount")]
    public long? MediaSheetCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pageCount")]
    public long? PageCount { get; set; }

    [JsonPropertyName("singleSidedSheetCount")]
    public long? SingleSidedSheetCount { get; set; }

    [JsonPropertyName("usageDate")]
    public DateTime? UsageDate { get; set; }
}
