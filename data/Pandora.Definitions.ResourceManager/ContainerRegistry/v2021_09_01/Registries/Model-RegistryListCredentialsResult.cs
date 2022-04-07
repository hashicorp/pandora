using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class RegistryListCredentialsResultModel
{
    [JsonPropertyName("passwords")]
    public List<RegistryPasswordModel>? Passwords { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
