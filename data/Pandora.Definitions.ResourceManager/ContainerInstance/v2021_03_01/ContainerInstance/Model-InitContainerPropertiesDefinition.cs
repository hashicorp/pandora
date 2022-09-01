using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_03_01.ContainerInstance;


internal class InitContainerPropertiesDefinitionModel
{
    [JsonPropertyName("command")]
    public List<string>? Command { get; set; }

    [JsonPropertyName("environmentVariables")]
    public List<EnvironmentVariableModel>? EnvironmentVariables { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("instanceView")]
    public InitContainerPropertiesDefinitionInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("volumeMounts")]
    public List<VolumeMountModel>? VolumeMounts { get; set; }
}
