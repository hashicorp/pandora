using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService
{

    internal class CommunicationServiceResourceModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("location")]
        public CustomTypes.Location? Location { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("properties")]
        public CommunicationServicePropertiesModel? Properties { get; set; }

        [JsonPropertyName("systemData")]
        public SystemDataModel? SystemData { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
