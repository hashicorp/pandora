using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.RedisEnterprise
{

    internal class DatabasePropertiesModel
    {
        [JsonPropertyName("clientProtocol")]
        public ProtocolConstant? ClientProtocol { get; set; }

        [JsonPropertyName("clusteringPolicy")]
        public ClusteringPolicyConstant? ClusteringPolicy { get; set; }

        [JsonPropertyName("evictionPolicy")]
        public EvictionPolicyConstant? EvictionPolicy { get; set; }

        [JsonPropertyName("modules")]
        public List<ModuleModel>? Modules { get; set; }

        [JsonPropertyName("persistence")]
        public PersistenceModel? Persistence { get; set; }

        [JsonPropertyName("port")]
        public int? Port { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("resourceState")]
        public ResourceStateConstant? ResourceState { get; set; }
    }
}
