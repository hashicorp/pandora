using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.EnvironmentVersion;


internal class InferenceContainerPropertiesModel
{
    [JsonPropertyName("livenessRoute")]
    public RouteModel? LivenessRoute { get; set; }

    [JsonPropertyName("readinessRoute")]
    public RouteModel? ReadinessRoute { get; set; }

    [JsonPropertyName("scoringRoute")]
    public RouteModel? ScoringRoute { get; set; }
}
