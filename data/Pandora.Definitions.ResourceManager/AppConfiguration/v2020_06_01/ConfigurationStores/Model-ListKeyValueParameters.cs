using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{

    internal class ListKeyValueParametersModel
    {
        [JsonPropertyName("key")]
        [Required]
        public string Key { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }
    }
}
