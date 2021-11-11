using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Application
{

    internal class ApplicationUpgradePolicyModel
    {
        [JsonPropertyName("applicationHealthPolicy")]
        public ApplicationHealthPolicyModel? ApplicationHealthPolicy { get; set; }

        [JsonPropertyName("forceRestart")]
        public bool? ForceRestart { get; set; }

        [JsonPropertyName("instanceCloseDelayDuration")]
        public int? InstanceCloseDelayDuration { get; set; }

        [JsonPropertyName("recreateApplication")]
        public bool? RecreateApplication { get; set; }

        [JsonPropertyName("rollingUpgradeMonitoringPolicy")]
        public RollingUpgradeMonitoringPolicyModel? RollingUpgradeMonitoringPolicy { get; set; }

        [JsonPropertyName("upgradeMode")]
        public RollingUpgradeModeConstant? UpgradeMode { get; set; }

        [JsonPropertyName("upgradeReplicaSetCheckTimeout")]
        public int? UpgradeReplicaSetCheckTimeout { get; set; }
    }
}
