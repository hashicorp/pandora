using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.PrivateEndpointConnections
{

    internal class PrivateEndpointModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}
