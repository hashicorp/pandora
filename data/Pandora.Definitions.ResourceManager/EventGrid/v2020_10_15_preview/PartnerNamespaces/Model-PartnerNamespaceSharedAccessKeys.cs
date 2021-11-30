using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerNamespaces
{

    internal class PartnerNamespaceSharedAccessKeysModel
    {
        [JsonPropertyName("key1")]
        public string? Key1 { get; set; }

        [JsonPropertyName("key2")]
        public string? Key2 { get; set; }
    }
}
