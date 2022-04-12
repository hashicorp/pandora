using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;


internal class VolumeModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("storageName")]
    public string? StorageName { get; set; }

    [JsonPropertyName("storageType")]
    public StorageTypeConstant? StorageType { get; set; }
}
