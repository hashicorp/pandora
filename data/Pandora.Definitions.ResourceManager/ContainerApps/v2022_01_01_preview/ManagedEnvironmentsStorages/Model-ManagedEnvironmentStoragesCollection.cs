using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironmentsStorages;


internal class ManagedEnvironmentStoragesCollectionModel
{
    [JsonPropertyName("value")]
    [Required]
    public List<ManagedEnvironmentStorageModel> Value { get; set; }
}
