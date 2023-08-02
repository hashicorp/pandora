// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkbookChartDataLabelsModel
{
    [JsonPropertyName("format")]
    public WorkbookChartDataLabelFormatModel? Format { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("position")]
    public string? Position { get; set; }

    [JsonPropertyName("separator")]
    public string? Separator { get; set; }

    [JsonPropertyName("showBubbleSize")]
    public bool? ShowBubbleSize { get; set; }

    [JsonPropertyName("showCategoryName")]
    public bool? ShowCategoryName { get; set; }

    [JsonPropertyName("showLegendKey")]
    public bool? ShowLegendKey { get; set; }

    [JsonPropertyName("showPercentage")]
    public bool? ShowPercentage { get; set; }

    [JsonPropertyName("showSeriesName")]
    public bool? ShowSeriesName { get; set; }

    [JsonPropertyName("showValue")]
    public bool? ShowValue { get; set; }
}
