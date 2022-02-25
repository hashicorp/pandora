using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.PrivateEndpointConnections;


internal class PrivateEndpointConnectionListResultModel
{
    [JsonPropertyName("value")]
    public List<PrivateEndpointConnectionModel>? Value { get; set; }
}
