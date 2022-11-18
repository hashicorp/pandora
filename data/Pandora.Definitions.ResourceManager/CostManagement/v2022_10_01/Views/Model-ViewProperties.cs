using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Views;


internal class ViewPropertiesModel
{
    [JsonPropertyName("accumulated")]
    public AccumulatedTypeConstant? Accumulated { get; set; }

    [JsonPropertyName("chart")]
    public ChartTypeConstant? Chart { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdOn")]
    public DateTime? CreatedOn { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("dateRange")]
    public string? DateRange { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("kpis")]
    public List<KpiPropertiesModel>? Kpis { get; set; }

    [JsonPropertyName("metric")]
    public MetricTypeConstant? Metric { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("modifiedOn")]
    public DateTime? ModifiedOn { get; set; }

    [JsonPropertyName("pivots")]
    public List<PivotPropertiesModel>? Pivots { get; set; }

    [JsonPropertyName("query")]
    public ReportConfigDefinitionModel? Query { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}
