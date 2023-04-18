using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;


internal class PerfCounterDataSourceModel
{
    [JsonPropertyName("counterSpecifiers")]
    public List<string>? CounterSpecifiers { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("samplingFrequencyInSeconds")]
    public int? SamplingFrequencyInSeconds { get; set; }

    [JsonPropertyName("streams")]
    public List<KnownPerfCounterDataSourceStreamsConstant>? Streams { get; set; }
}
