using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Query;


internal class QueryDefinitionModel
{
    [JsonPropertyName("dataset")]
    [Required]
    public QueryDatasetModel Dataset { get; set; }

    [JsonPropertyName("timePeriod")]
    public QueryTimePeriodModel? TimePeriod { get; set; }

    [JsonPropertyName("timeframe")]
    [Required]
    public TimeframeTypeConstant Timeframe { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public ExportTypeConstant Type { get; set; }
}
