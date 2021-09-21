using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Account
{

    internal class ManagedResourcesModel
    {
        [JsonPropertyName("eventHubNamespace")]
        public string? EventHubNamespace { get; set; }

        [JsonPropertyName("resourceGroup")]
        public string? ResourceGroup { get; set; }

        [JsonPropertyName("storageAccount")]
        public string? StorageAccount { get; set; }
    }
}
