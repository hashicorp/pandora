using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.BandwidthSchedules;


internal class BandwidthSchedulePropertiesModel
{
    [JsonPropertyName("days")]
    [Required]
    public List<DayOfWeekConstant> Days { get; set; }

    [JsonPropertyName("rateInMbps")]
    [Required]
    public int RateInMbps { get; set; }

    [JsonPropertyName("start")]
    [Required]
    public string Start { get; set; }

    [JsonPropertyName("stop")]
    [Required]
    public string Stop { get; set; }
}
