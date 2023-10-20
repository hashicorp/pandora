using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.OperationalizationClusters;


internal class CustomServiceModel
{
    [JsonPropertyName("docker")]
    public DockerModel? Docker { get; set; }

    [JsonPropertyName("endpoints")]
    public List<EndpointModel>? Endpoints { get; set; }

    [JsonPropertyName("environmentVariables")]
    public Dictionary<string, EnvironmentVariableModel>? EnvironmentVariables { get; set; }

    [JsonPropertyName("image")]
    public ImageModel? Image { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("volumes")]
    public List<VolumeDefinitionModel>? Volumes { get; set; }
}
