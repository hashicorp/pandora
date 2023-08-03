// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrinterCapabilitiesModel
{
    [JsonPropertyName("bottomMargins")]
    public List<int>? BottomMargins { get; set; }

    [JsonPropertyName("collation")]
    public bool? Collation { get; set; }

    [JsonPropertyName("colorModes")]
    public List<PrintColorModeConstant>? ColorModes { get; set; }

    [JsonPropertyName("contentTypes")]
    public List<string>? ContentTypes { get; set; }

    [JsonPropertyName("copiesPerJob")]
    public IntegerRangeModel? CopiesPerJob { get; set; }

    [JsonPropertyName("dpis")]
    public List<int>? Dpis { get; set; }

    [JsonPropertyName("duplexModes")]
    public List<PrintDuplexModeConstant>? DuplexModes { get; set; }

    [JsonPropertyName("feedDirections")]
    public List<PrinterFeedDirectionConstant>? FeedDirections { get; set; }

    [JsonPropertyName("feedOrientations")]
    public List<PrinterFeedOrientationConstant>? FeedOrientations { get; set; }

    [JsonPropertyName("finishings")]
    public List<PrintFinishingConstant>? Finishings { get; set; }

    [JsonPropertyName("inputBins")]
    public List<string>? InputBins { get; set; }

    [JsonPropertyName("isColorPrintingSupported")]
    public bool? IsColorPrintingSupported { get; set; }

    [JsonPropertyName("isPageRangeSupported")]
    public bool? IsPageRangeSupported { get; set; }

    [JsonPropertyName("leftMargins")]
    public List<int>? LeftMargins { get; set; }

    [JsonPropertyName("mediaColors")]
    public List<string>? MediaColors { get; set; }

    [JsonPropertyName("mediaSizes")]
    public List<string>? MediaSizes { get; set; }

    [JsonPropertyName("mediaTypes")]
    public List<string>? MediaTypes { get; set; }

    [JsonPropertyName("multipageLayouts")]
    public List<PrintMultipageLayoutConstant>? MultipageLayouts { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("orientations")]
    public List<PrintOrientationConstant>? Orientations { get; set; }

    [JsonPropertyName("outputBins")]
    public List<string>? OutputBins { get; set; }

    [JsonPropertyName("pagesPerSheet")]
    public List<int>? PagesPerSheet { get; set; }

    [JsonPropertyName("qualities")]
    public List<PrintQualityConstant>? Qualities { get; set; }

    [JsonPropertyName("rightMargins")]
    public List<int>? RightMargins { get; set; }

    [JsonPropertyName("scalings")]
    public List<PrintScalingConstant>? Scalings { get; set; }

    [JsonPropertyName("supportedColorConfigurations")]
    public List<PrintColorConfigurationConstant>? SupportedColorConfigurations { get; set; }

    [JsonPropertyName("supportedCopiesPerJob")]
    public IntegerRangeModel? SupportedCopiesPerJob { get; set; }

    [JsonPropertyName("supportedDocumentMimeTypes")]
    public List<string>? SupportedDocumentMimeTypes { get; set; }

    [JsonPropertyName("supportedDuplexConfigurations")]
    public List<PrintDuplexConfigurationConstant>? SupportedDuplexConfigurations { get; set; }

    [JsonPropertyName("supportedFinishings")]
    public List<PrintFinishingConstant>? SupportedFinishings { get; set; }

    [JsonPropertyName("supportedMediaColors")]
    public List<string>? SupportedMediaColors { get; set; }

    [JsonPropertyName("supportedMediaSizes")]
    public List<string>? SupportedMediaSizes { get; set; }

    [JsonPropertyName("supportedMediaTypes")]
    public List<PrintMediaTypeConstant>? SupportedMediaTypes { get; set; }

    [JsonPropertyName("supportedOrientations")]
    public List<PrintOrientationConstant>? SupportedOrientations { get; set; }

    [JsonPropertyName("supportedOutputBins")]
    public List<string>? SupportedOutputBins { get; set; }

    [JsonPropertyName("supportedPagesPerSheet")]
    public IntegerRangeModel? SupportedPagesPerSheet { get; set; }

    [JsonPropertyName("supportedPresentationDirections")]
    public List<PrintPresentationDirectionConstant>? SupportedPresentationDirections { get; set; }

    [JsonPropertyName("supportedPrintQualities")]
    public List<PrintQualityConstant>? SupportedPrintQualities { get; set; }

    [JsonPropertyName("supportsFitPdfToPage")]
    public bool? SupportsFitPdfToPage { get; set; }

    [JsonPropertyName("topMargins")]
    public List<int>? TopMargins { get; set; }
}
