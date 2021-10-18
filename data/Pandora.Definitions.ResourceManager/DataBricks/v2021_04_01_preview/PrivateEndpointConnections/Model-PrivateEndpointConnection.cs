using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.PrivateEndpointConnections
{

    internal class PrivateEndpointConnectionModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("properties")]
        [Required]
        public PrivateEndpointConnectionPropertiesModel Properties { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
