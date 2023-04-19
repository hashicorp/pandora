using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2023_01_01.AdvisorScore;


internal class AdvisorScoreEntityPropertiesModel
{
    [JsonPropertyName("lastRefreshedScore")]
    public ScoreEntityModel? LastRefreshedScore { get; set; }

    [JsonPropertyName("timeSeries")]
    public List<TimeSeriesEntityTimeSeriesInlinedModel>? TimeSeries { get; set; }
}
