using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;


internal class ClusterUpgradePolicyModel
{
    [JsonPropertyName("deltaHealthPolicy")]
    public ClusterUpgradeDeltaHealthPolicyModel? DeltaHealthPolicy { get; set; }

    [JsonPropertyName("forceRestart")]
    public bool? ForceRestart { get; set; }

    [JsonPropertyName("healthCheckRetryTimeout")]
    [Required]
    public string HealthCheckRetryTimeout { get; set; }

    [JsonPropertyName("healthCheckStableDuration")]
    [Required]
    public string HealthCheckStableDuration { get; set; }

    [JsonPropertyName("healthCheckWaitDuration")]
    [Required]
    public string HealthCheckWaitDuration { get; set; }

    [JsonPropertyName("healthPolicy")]
    [Required]
    public ClusterHealthPolicyModel HealthPolicy { get; set; }

    [JsonPropertyName("upgradeDomainTimeout")]
    [Required]
    public string UpgradeDomainTimeout { get; set; }

    [JsonPropertyName("upgradeReplicaSetCheckTimeout")]
    [Required]
    public string UpgradeReplicaSetCheckTimeout { get; set; }

    [JsonPropertyName("upgradeTimeout")]
    [Required]
    public string UpgradeTimeout { get; set; }
}
