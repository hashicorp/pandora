// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrinterDocumentConfigurationModel
{
    [JsonPropertyName("collate")]
    public bool? Collate { get; set; }

    [JsonPropertyName("colorMode")]
    public PrinterDocumentConfigurationColorModeConstant? ColorMode { get; set; }

    [JsonPropertyName("copies")]
    public int? Copies { get; set; }

    [JsonPropertyName("dpi")]
    public int? Dpi { get; set; }

    [JsonPropertyName("duplexMode")]
    public PrinterDocumentConfigurationDuplexModeConstant? DuplexMode { get; set; }

    [JsonPropertyName("feedDirection")]
    public PrinterDocumentConfigurationFeedDirectionConstant? FeedDirection { get; set; }

    [JsonPropertyName("feedOrientation")]
    public PrinterDocumentConfigurationFeedOrientationConstant? FeedOrientation { get; set; }

    [JsonPropertyName("finishings")]
    public List<PrinterDocumentConfigurationFinishingsConstant>? Finishings { get; set; }

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
    public PrinterDocumentConfigurationMultipageLayoutConstant? MultipageLayout { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("orientation")]
    public PrinterDocumentConfigurationOrientationConstant? Orientation { get; set; }

    [JsonPropertyName("outputBin")]
    public string? OutputBin { get; set; }

    [JsonPropertyName("pageRanges")]
    public List<IntegerRangeModel>? PageRanges { get; set; }

    [JsonPropertyName("pagesPerSheet")]
    public int? PagesPerSheet { get; set; }

    [JsonPropertyName("quality")]
    public PrinterDocumentConfigurationQualityConstant? Quality { get; set; }

    [JsonPropertyName("scaling")]
    public PrinterDocumentConfigurationScalingConstant? Scaling { get; set; }
}
