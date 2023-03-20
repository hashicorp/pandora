using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;

[ValueForType("Docker")]
internal class DockerBuildStepModel : TaskStepPropertiesModel
{
    [JsonPropertyName("arguments")]
    public List<ArgumentModel>? Arguments { get; set; }

    [JsonPropertyName("dockerFilePath")]
    [Required]
    public string DockerFilePath { get; set; }

    [JsonPropertyName("imageNames")]
    public List<string>? ImageNames { get; set; }

    [JsonPropertyName("isPushEnabled")]
    public bool? IsPushEnabled { get; set; }

    [JsonPropertyName("noCache")]
    public bool? NoCache { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }
}
