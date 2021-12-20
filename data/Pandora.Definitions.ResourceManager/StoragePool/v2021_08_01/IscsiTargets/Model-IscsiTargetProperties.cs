using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.IscsiTargets
{

    internal class IscsiTargetPropertiesModel
    {
        [JsonPropertyName("aclMode")]
        [Required]
        public IscsiTargetAclModeConstant AclMode { get; set; }

        [JsonPropertyName("endpoints")]
        public List<string>? Endpoints { get; set; }

        [JsonPropertyName("luns")]
        public List<IscsiLunModel>? Luns { get; set; }

        [JsonPropertyName("port")]
        public int? Port { get; set; }

        [JsonPropertyName("provisioningState")]
        [Required]
        public ProvisioningStatesConstant ProvisioningState { get; set; }

        [JsonPropertyName("sessions")]
        public List<string>? Sessions { get; set; }

        [JsonPropertyName("staticAcls")]
        public List<AclModel>? StaticAcls { get; set; }

        [JsonPropertyName("status")]
        [Required]
        public OperationalStatusConstant Status { get; set; }

        [JsonPropertyName("targetIqn")]
        [Required]
        public string TargetIqn { get; set; }
    }
}
