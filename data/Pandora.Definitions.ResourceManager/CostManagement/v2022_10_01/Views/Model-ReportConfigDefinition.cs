using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Views;


internal class ReportConfigDefinitionModel
{
    [JsonPropertyName("dataSet")]
    public ReportConfigDatasetModel? DataSet { get; set; }

    [JsonPropertyName("includeMonetaryCommitment")]
    public bool? IncludeMonetaryCommitment { get; set; }

    [JsonPropertyName("timePeriod")]
    public ReportConfigTimePeriodModel? TimePeriod { get; set; }

    [JsonPropertyName("timeframe")]
    [Required]
    public ReportTimeframeTypeConstant Timeframe { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public ReportTypeConstant Type { get; set; }
}
