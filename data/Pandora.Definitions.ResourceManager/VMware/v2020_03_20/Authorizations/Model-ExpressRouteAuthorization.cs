using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{

    internal class ExpressRouteAuthorizationModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("properties")]
        public ExpressRouteAuthorizationPropertiesModel? Properties { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
