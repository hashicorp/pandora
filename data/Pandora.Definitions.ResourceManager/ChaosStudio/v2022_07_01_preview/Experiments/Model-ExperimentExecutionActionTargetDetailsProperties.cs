using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview.Experiments;


internal class ExperimentExecutionActionTargetDetailsPropertiesModel
{
    [JsonPropertyName("error")]
    public ExperimentExecutionActionTargetDetailsErrorModel? Error { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("targetCompletedTime")]
    public DateTime? TargetCompletedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("targetFailedTime")]
    public DateTime? TargetFailedTime { get; set; }
}
