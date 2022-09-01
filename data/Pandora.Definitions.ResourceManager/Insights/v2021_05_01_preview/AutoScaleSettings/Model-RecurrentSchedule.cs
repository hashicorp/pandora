using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.AutoScaleSettings;


internal class RecurrentScheduleModel
{
    [JsonPropertyName("days")]
    [Required]
    public List<string> Days { get; set; }

    [JsonPropertyName("hours")]
    [Required]
    public List<int> Hours { get; set; }

    [JsonPropertyName("minutes")]
    [Required]
    public List<int> Minutes { get; set; }

    [JsonPropertyName("timeZone")]
    [Required]
    public string TimeZone { get; set; }
}
