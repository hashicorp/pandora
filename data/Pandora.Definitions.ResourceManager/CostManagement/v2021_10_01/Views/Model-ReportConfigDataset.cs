using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views;


internal class ReportConfigDatasetModel
{
    [JsonPropertyName("aggregation")]
    public Dictionary<string, ReportConfigAggregationModel>? Aggregation { get; set; }

    [JsonPropertyName("configuration")]
    public ReportConfigDatasetConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("filter")]
    public ReportConfigFilterModel? Filter { get; set; }

    [JsonPropertyName("granularity")]
    public ReportGranularityTypeConstant? Granularity { get; set; }

    [MaxItems(2)]
    [JsonPropertyName("grouping")]
    public List<ReportConfigGroupingModel>? Grouping { get; set; }

    [JsonPropertyName("sorting")]
    public List<ReportConfigSortingModel>? Sorting { get; set; }
}
