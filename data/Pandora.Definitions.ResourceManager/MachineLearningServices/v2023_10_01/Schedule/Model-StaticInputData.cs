using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ValueForType("Static")]
internal class StaticInputDataModel : MonitoringInputDataBaseModel
{
    [JsonPropertyName("preprocessingComponentId")]
    public string? PreprocessingComponentId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("windowEnd")]
    [Required]
    public DateTime WindowEnd { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("windowStart")]
    [Required]
    public DateTime WindowStart { get; set; }
}
