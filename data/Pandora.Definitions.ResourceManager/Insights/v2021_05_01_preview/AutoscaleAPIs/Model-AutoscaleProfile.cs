using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.AutoscaleAPIs;


internal class AutoscaleProfileModel
{
    [JsonPropertyName("capacity")]
    [Required]
    public ScaleCapacityModel Capacity { get; set; }

    [JsonPropertyName("fixedDate")]
    public TimeWindowModel? FixedDate { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("recurrence")]
    public RecurrenceModel? Recurrence { get; set; }

    [JsonPropertyName("rules")]
    [Required]
    public List<ScaleRuleModel> Rules { get; set; }
}
