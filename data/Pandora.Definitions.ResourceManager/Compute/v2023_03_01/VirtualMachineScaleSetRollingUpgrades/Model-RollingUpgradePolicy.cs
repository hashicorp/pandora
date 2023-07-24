using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineScaleSetRollingUpgrades;


internal class RollingUpgradePolicyModel
{
    [JsonPropertyName("enableCrossZoneUpgrade")]
    public bool? EnableCrossZoneUpgrade { get; set; }

    [JsonPropertyName("maxBatchInstancePercent")]
    public int? MaxBatchInstancePercent { get; set; }

    [JsonPropertyName("maxSurge")]
    public bool? MaxSurge { get; set; }

    [JsonPropertyName("maxUnhealthyInstancePercent")]
    public int? MaxUnhealthyInstancePercent { get; set; }

    [JsonPropertyName("maxUnhealthyUpgradedInstancePercent")]
    public int? MaxUnhealthyUpgradedInstancePercent { get; set; }

    [JsonPropertyName("pauseTimeBetweenBatches")]
    public string? PauseTimeBetweenBatches { get; set; }

    [JsonPropertyName("prioritizeUnhealthyInstances")]
    public bool? PrioritizeUnhealthyInstances { get; set; }

    [JsonPropertyName("rollbackFailedInstancesOnPolicyBreach")]
    public bool? RollbackFailedInstancesOnPolicyBreach { get; set; }
}
