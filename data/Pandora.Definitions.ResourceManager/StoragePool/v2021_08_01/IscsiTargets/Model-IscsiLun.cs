using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.IscsiTargets
{

    internal class IscsiLunModel
    {
        [JsonPropertyName("lun")]
        public int? Lun { get; set; }

        [JsonPropertyName("managedDiskAzureResourceId")]
        [Required]
        public string ManagedDiskAzureResourceId { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    }
}
