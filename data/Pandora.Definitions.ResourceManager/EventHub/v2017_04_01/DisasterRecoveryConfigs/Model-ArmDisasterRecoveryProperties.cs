using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.DisasterRecoveryConfigs
{

    internal class ArmDisasterRecoveryProperties
    {
        [JsonPropertyName("alternateName")]
        public string? AlternateName { get; set; }

        [JsonPropertyName("partnerNamespace")]
        public string? PartnerNamespace { get; set; }

        [JsonPropertyName("pendingReplicationOperationsCount")]
        public int PendingReplicationOperationsCount { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningStateDR ProvisioningState { get; set; }

        [JsonPropertyName("role")]
        public RoleDisasterRecovery Role { get; set; }
    }
}
