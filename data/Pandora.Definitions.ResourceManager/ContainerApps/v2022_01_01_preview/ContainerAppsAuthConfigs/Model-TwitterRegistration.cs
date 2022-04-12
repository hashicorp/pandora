using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class TwitterRegistrationModel
{
    [JsonPropertyName("consumerKey")]
    public string? ConsumerKey { get; set; }

    [JsonPropertyName("consumerSecretSettingName")]
    public string? ConsumerSecretSettingName { get; set; }
}
