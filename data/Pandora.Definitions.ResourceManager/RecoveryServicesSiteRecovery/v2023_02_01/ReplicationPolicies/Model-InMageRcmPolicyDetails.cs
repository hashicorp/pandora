using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationPolicies;

[ValueForType("InMageRcm")]
internal class InMageRcmPolicyDetailsModel : PolicyProviderSpecificDetailsModel
{
    [JsonPropertyName("appConsistentFrequencyInMinutes")]
    public int? AppConsistentFrequencyInMinutes { get; set; }

    [JsonPropertyName("crashConsistentFrequencyInMinutes")]
    public int? CrashConsistentFrequencyInMinutes { get; set; }

    [JsonPropertyName("enableMultiVmSync")]
    public string? EnableMultiVMSync { get; set; }

    [JsonPropertyName("recoveryPointHistoryInMinutes")]
    public int? RecoveryPointHistoryInMinutes { get; set; }
}
