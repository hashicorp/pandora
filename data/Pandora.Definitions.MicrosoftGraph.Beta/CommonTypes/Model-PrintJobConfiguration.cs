// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrintJobConfigurationModel
{
    [JsonPropertyName("collate")]
    public bool? Collate { get; set; }

    [JsonPropertyName("colorMode")]
    public PrintJobConfigurationColorModeConstant? ColorMode { get; set; }

    [JsonPropertyName("copies")]
    public int? Copies { get; set; }

    [JsonPropertyName("dpi")]
    public int? Dpi { get; set; }

    [JsonPropertyName("duplexMode")]
    public PrintJobConfigurationDuplexModeConstant? DuplexMode { get; set; }

    [JsonPropertyName("feedOrientation")]
    public PrintJobConfigurationFeedOrientationConstant? FeedOrientation { get; set; }

    [JsonPropertyName("finishings")]
    public List<PrintJobConfigurationFinishingsConstant>? Finishings { get; set; }

    [JsonPropertyName("fitPdfToPage")]
    public bool? FitPdfToPage { get; set; }

    [JsonPropertyName("inputBin")]
    public string? InputBin { get; set; }

    [JsonPropertyName("margin")]
    public PrintMarginModel? Margin { get; set; }

    [JsonPropertyName("mediaSize")]
    public string? MediaSize { get; set; }

    [JsonPropertyName("mediaType")]
    public string? MediaType { get; set; }

    [JsonPropertyName("multipageLayout")]
    public PrintJobConfigurationMultipageLayoutConstant? MultipageLayout { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("orientation")]
    public PrintJobConfigurationOrientationConstant? Orientation { get; set; }

    [JsonPropertyName("outputBin")]
    public string? OutputBin { get; set; }

    [JsonPropertyName("pageRanges")]
    public List<IntegerRangeModel>? PageRanges { get; set; }

    [JsonPropertyName("pagesPerSheet")]
    public int? PagesPerSheet { get; set; }

    [JsonPropertyName("quality")]
    public PrintJobConfigurationQualityConstant? Quality { get; set; }

    [JsonPropertyName("scaling")]
    public PrintJobConfigurationScalingConstant? Scaling { get; set; }
}
