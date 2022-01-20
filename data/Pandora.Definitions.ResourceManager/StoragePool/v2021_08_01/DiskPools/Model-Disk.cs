using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools;


internal class DiskModel
{
    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }
}
