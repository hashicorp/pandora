// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class WorkbookChartAxisModel
{
    [JsonPropertyName("format")]
    public WorkbookChartAxisFormatModel? Format { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("majorGridlines")]
    public WorkbookChartGridlinesModel? MajorGridlines { get; set; }

    [JsonPropertyName("majorUnit")]
    public JsonModel? MajorUnit { get; set; }

    [JsonPropertyName("maximum")]
    public JsonModel? Maximum { get; set; }

    [JsonPropertyName("minimum")]
    public JsonModel? Minimum { get; set; }

    [JsonPropertyName("minorGridlines")]
    public WorkbookChartGridlinesModel? MinorGridlines { get; set; }

    [JsonPropertyName("minorUnit")]
    public JsonModel? MinorUnit { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("title")]
    public WorkbookChartAxisTitleModel? Title { get; set; }
}
