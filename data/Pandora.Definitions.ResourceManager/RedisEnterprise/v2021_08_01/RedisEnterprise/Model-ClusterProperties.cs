using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.RedisEnterprise
{

    internal class ClusterPropertiesModel
    {
        [JsonPropertyName("hostName")]
        public string? HostName { get; set; }

        [JsonPropertyName("minimumTlsVersion")]
        public TlsVersionConstant? MinimumTlsVersion { get; set; }

        [JsonPropertyName("privateEndpointConnections")]
        public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("redisVersion")]
        public string? RedisVersion { get; set; }

        [JsonPropertyName("resourceState")]
        public ResourceStateConstant? ResourceState { get; set; }
    }
}
