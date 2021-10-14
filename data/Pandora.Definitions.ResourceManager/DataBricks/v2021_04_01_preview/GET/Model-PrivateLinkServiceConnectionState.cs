using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.GET
{

    internal class PrivateLinkServiceConnectionStateModel
    {
        [JsonPropertyName("actionRequired")]
        public string? ActionRequired { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("status")]
        [Required]
        public PrivateLinkServiceConnectionStatusConstant Status { get; set; }
    }
}
