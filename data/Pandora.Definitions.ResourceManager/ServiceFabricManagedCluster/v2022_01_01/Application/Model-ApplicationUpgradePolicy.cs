using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Application;


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
