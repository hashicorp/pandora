using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSetRollingUpgrades;


internal class RollingUpgradeStatusInfoPropertiesModel
{
    [JsonPropertyName("error")]
    public ApiErrorModel? Error { get; set; }

    [JsonPropertyName("policy")]
    public RollingUpgradePolicyModel? Policy { get; set; }

    [JsonPropertyName("progress")]
    public RollingUpgradeProgressInfoModel? Progress { get; set; }

    [JsonPropertyName("runningStatus")]
    public RollingUpgradeRunningStatusModel? RunningStatus { get; set; }
}
