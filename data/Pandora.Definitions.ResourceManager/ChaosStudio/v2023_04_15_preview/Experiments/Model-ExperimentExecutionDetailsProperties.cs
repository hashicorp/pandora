using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2023_04_15_preview.Experiments;


internal class ExperimentExecutionDetailsPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("experimentId")]
    public string? ExperimentId { get; set; }

    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastActionDateTime")]
    public DateTime? LastActionDateTime { get; set; }

    [JsonPropertyName("runInformation")]
    public ExperimentExecutionDetailsPropertiesRunInformationModel? RunInformation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("stopDateTime")]
    public DateTime? StopDateTime { get; set; }
}
