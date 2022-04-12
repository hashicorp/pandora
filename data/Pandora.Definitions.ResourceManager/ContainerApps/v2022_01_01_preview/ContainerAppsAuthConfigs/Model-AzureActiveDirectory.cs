using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class AzureActiveDirectoryModel
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("isAutoProvisioned")]
    public bool? IsAutoProvisioned { get; set; }

    [JsonPropertyName("login")]
    public AzureActiveDirectoryLoginModel? Login { get; set; }

    [JsonPropertyName("registration")]
    public AzureActiveDirectoryRegistrationModel? Registration { get; set; }

    [JsonPropertyName("validation")]
    public AzureActiveDirectoryValidationModel? Validation { get; set; }
}
