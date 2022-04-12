using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsSourceControls;


internal class GithubActionConfigurationModel
{
    [JsonPropertyName("azureCredentials")]
    public AzureCredentialsModel? AzureCredentials { get; set; }

    [JsonPropertyName("dockerfilePath")]
    public string? DockerfilePath { get; set; }

    [JsonPropertyName("os")]
    public string? Os { get; set; }

    [JsonPropertyName("publishType")]
    public string? PublishType { get; set; }

    [JsonPropertyName("registryInfo")]
    public RegistryInfoModel? RegistryInfo { get; set; }

    [JsonPropertyName("runtimeStack")]
    public string? RuntimeStack { get; set; }

    [JsonPropertyName("runtimeVersion")]
    public string? RuntimeVersion { get; set; }
}
