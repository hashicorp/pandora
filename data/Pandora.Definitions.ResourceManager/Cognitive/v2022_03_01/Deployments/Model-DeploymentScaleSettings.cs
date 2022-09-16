using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_03_01.Deployments;


internal class DeploymentScaleSettingsModel
{
    [JsonPropertyName("activeCapacity")]
    public int? ActiveCapacity { get; set; }

    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    [JsonPropertyName("scaleType")]
    public DeploymentScaleTypeConstant? ScaleType { get; set; }
}
