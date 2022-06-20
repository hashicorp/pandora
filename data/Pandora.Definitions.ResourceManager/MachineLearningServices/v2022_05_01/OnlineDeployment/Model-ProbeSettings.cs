using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OnlineDeployment;


internal class ProbeSettingsModel
{
    [JsonPropertyName("failureThreshold")]
    public int? FailureThreshold { get; set; }

    [JsonPropertyName("initialDelay")]
    public string? InitialDelay { get; set; }

    [JsonPropertyName("period")]
    public string? Period { get; set; }

    [JsonPropertyName("successThreshold")]
    public int? SuccessThreshold { get; set; }

    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }
}
