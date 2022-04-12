using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsSourceControls;


internal class SourceControlPropertiesModel
{
    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("githubActionConfiguration")]
    public GithubActionConfigurationModel? GithubActionConfiguration { get; set; }

    [JsonPropertyName("operationState")]
    public SourceControlOperationStateConstant? OperationState { get; set; }

    [JsonPropertyName("repoUrl")]
    public string? RepoUrl { get; set; }
}
