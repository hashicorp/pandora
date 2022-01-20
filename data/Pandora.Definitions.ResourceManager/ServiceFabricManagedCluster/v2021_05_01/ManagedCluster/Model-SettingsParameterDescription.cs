using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedCluster;


internal class SettingsParameterDescriptionModel
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public string Value { get; set; }
}
