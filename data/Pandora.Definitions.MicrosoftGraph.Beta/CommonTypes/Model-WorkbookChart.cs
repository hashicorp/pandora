// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkbookChartModel
{
    [JsonPropertyName("axes")]
    public WorkbookChartAxesModel? Axes { get; set; }

    [JsonPropertyName("dataLabels")]
    public WorkbookChartDataLabelsModel? DataLabels { get; set; }

    [JsonPropertyName("format")]
    public WorkbookChartAreaFormatModel? Format { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("legend")]
    public WorkbookChartLegendModel? Legend { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("series")]
    public List<WorkbookChartSeriesModel>? Series { get; set; }

    [JsonPropertyName("title")]
    public WorkbookChartTitleModel? Title { get; set; }

    [JsonPropertyName("worksheet")]
    public WorkbookWorksheetModel? Worksheet { get; set; }
}
