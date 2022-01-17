using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.ServerGroups
{

    internal class NameAvailabilityModel
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("nameAvailable")]
        public bool? NameAvailable { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
