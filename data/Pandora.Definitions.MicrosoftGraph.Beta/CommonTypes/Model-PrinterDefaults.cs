// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrinterDefaultsModel
{
    [JsonPropertyName("colorMode")]
    public PrinterDefaultsColorModeConstant? ColorMode { get; set; }

    [JsonPropertyName("contentType")]
    public string? ContentType { get; set; }

    [JsonPropertyName("copiesPerJob")]
    public int? CopiesPerJob { get; set; }

    [JsonPropertyName("documentMimeType")]
    public string? DocumentMimeType { get; set; }

    [JsonPropertyName("dpi")]
    public int? Dpi { get; set; }

    [JsonPropertyName("duplexConfiguration")]
    public PrinterDefaultsDuplexConfigurationConstant? DuplexConfiguration { get; set; }

    [JsonPropertyName("duplexMode")]
    public PrinterDefaultsDuplexModeConstant? DuplexMode { get; set; }

    [JsonPropertyName("finishings")]
    public List<PrinterDefaultsFinishingsConstant>? Finishings { get; set; }

    [JsonPropertyName("fitPdfToPage")]
    public bool? FitPdfToPage { get; set; }

    [JsonPropertyName("inputBin")]
    public string? InputBin { get; set; }

    [JsonPropertyName("mediaColor")]
    public string? MediaColor { get; set; }

    [JsonPropertyName("mediaSize")]
    public string? MediaSize { get; set; }

    [JsonPropertyName("mediaType")]
    public string? MediaType { get; set; }

    [JsonPropertyName("multipageLayout")]
    public PrinterDefaultsMultipageLayoutConstant? MultipageLayout { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("orientation")]
    public PrinterDefaultsOrientationConstant? Orientation { get; set; }

    [JsonPropertyName("outputBin")]
    public string? OutputBin { get; set; }

    [JsonPropertyName("pagesPerSheet")]
    public int? PagesPerSheet { get; set; }

    [JsonPropertyName("pdfFitToPage")]
    public bool? PdfFitToPage { get; set; }

    [JsonPropertyName("presentationDirection")]
    public PrinterDefaultsPresentationDirectionConstant? PresentationDirection { get; set; }

    [JsonPropertyName("printColorConfiguration")]
    public PrinterDefaultsPrintColorConfigurationConstant? PrintColorConfiguration { get; set; }

    [JsonPropertyName("printQuality")]
    public PrinterDefaultsPrintQualityConstant? PrintQuality { get; set; }

    [JsonPropertyName("quality")]
    public PrinterDefaultsQualityConstant? Quality { get; set; }

    [JsonPropertyName("scaling")]
    public PrinterDefaultsScalingConstant? Scaling { get; set; }
}
