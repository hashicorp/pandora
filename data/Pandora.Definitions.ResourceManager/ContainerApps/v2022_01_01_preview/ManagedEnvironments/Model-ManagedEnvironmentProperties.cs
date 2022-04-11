using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironments;


internal class ManagedEnvironmentPropertiesModel
{
    [JsonPropertyName("appLogsConfiguration")]
    public AppLogsConfigurationModel? AppLogsConfiguration { get; set; }

    [JsonPropertyName("daprAIInstrumentationKey")]
    public string? DaprAIInstrumentationKey { get; set; }

    [JsonPropertyName("defaultDomain")]
    public string? DefaultDomain { get; set; }

    [JsonPropertyName("deploymentErrors")]
    public string? DeploymentErrors { get; set; }

    [JsonPropertyName("provisioningState")]
    public EnvironmentProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("staticIp")]
    public string? StaticIp { get; set; }

    [JsonPropertyName("vnetConfiguration")]
    public VnetConfigurationModel? VnetConfiguration { get; set; }
}
