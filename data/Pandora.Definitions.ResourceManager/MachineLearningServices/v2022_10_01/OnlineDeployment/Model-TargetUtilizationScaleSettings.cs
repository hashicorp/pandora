using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OnlineDeployment;

[ValueForType("TargetUtilization")]
internal class TargetUtilizationScaleSettingsModel : OnlineScaleSettingsModel
{
    [JsonPropertyName("maxInstances")]
    public int? MaxInstances { get; set; }

    [JsonPropertyName("minInstances")]
    public int? MinInstances { get; set; }

    [JsonPropertyName("pollingInterval")]
    public string? PollingInterval { get; set; }

    [JsonPropertyName("targetUtilizationPercentage")]
    public int? TargetUtilizationPercentage { get; set; }
}
