using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationPolicies;

[ValueForType("InMageBasePolicyDetails")]
internal class InMageBasePolicyDetailsModel : PolicyProviderSpecificDetailsModel
{
    [JsonPropertyName("appConsistentFrequencyInMinutes")]
    public int? AppConsistentFrequencyInMinutes { get; set; }

    [JsonPropertyName("multiVmSyncStatus")]
    public string? MultiVMSyncStatus { get; set; }

    [JsonPropertyName("recoveryPointHistory")]
    public int? RecoveryPointHistory { get; set; }

    [JsonPropertyName("recoveryPointThresholdInMinutes")]
    public int? RecoveryPointThresholdInMinutes { get; set; }
}
