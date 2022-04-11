using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;


internal class ConfigurationModel
{
    [JsonPropertyName("activeRevisionsMode")]
    public ActiveRevisionsModeConstant? ActiveRevisionsMode { get; set; }

    [JsonPropertyName("dapr")]
    public DaprModel? Dapr { get; set; }

    [JsonPropertyName("ingress")]
    public IngressModel? Ingress { get; set; }

    [JsonPropertyName("registries")]
    public List<RegistryCredentialsModel>? Registries { get; set; }

    [JsonPropertyName("secrets")]
    public List<SecretModel>? Secrets { get; set; }
}
