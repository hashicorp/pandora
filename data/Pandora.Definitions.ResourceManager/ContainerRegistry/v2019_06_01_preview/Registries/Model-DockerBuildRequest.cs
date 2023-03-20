using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Registries;

[ValueForType("DockerBuildRequest")]
internal class DockerBuildRequestModel : RunRequestModel
{
    [JsonPropertyName("agentConfiguration")]
    public AgentPropertiesModel? AgentConfiguration { get; set; }

    [JsonPropertyName("arguments")]
    public List<ArgumentModel>? Arguments { get; set; }

    [JsonPropertyName("credentials")]
    public CredentialsModel? Credentials { get; set; }

    [JsonPropertyName("dockerFilePath")]
    [Required]
    public string DockerFilePath { get; set; }

    [JsonPropertyName("imageNames")]
    public List<string>? ImageNames { get; set; }

    [JsonPropertyName("isPushEnabled")]
    public bool? IsPushEnabled { get; set; }

    [JsonPropertyName("noCache")]
    public bool? NoCache { get; set; }

    [JsonPropertyName("platform")]
    [Required]
    public PlatformPropertiesModel Platform { get; set; }

    [JsonPropertyName("sourceLocation")]
    public string? SourceLocation { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }
}
