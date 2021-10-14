using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.Workspaces
{

    internal class EncryptionModel
    {
        [JsonPropertyName("KeyName")]
        public string? KeyName { get; set; }

        [JsonPropertyName("keySource")]
        public KeySourceConstant? KeySource { get; set; }

        [JsonPropertyName("keyvaulturi")]
        public string? Keyvaulturi { get; set; }

        [JsonPropertyName("keyversion")]
        public string? Keyversion { get; set; }
    }
}
