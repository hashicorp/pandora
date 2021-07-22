using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.DisasterRecoveryConfigs
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
