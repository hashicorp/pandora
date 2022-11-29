using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectionIntents;

[ValueForType("New")]
internal class NewProtectionProfileModel : ProtectionProfileCustomDetailsModel
{
    [JsonPropertyName("appConsistentFrequencyInMinutes")]
    public int? AppConsistentFrequencyInMinutes { get; set; }

    [JsonPropertyName("crashConsistentFrequencyInMinutes")]
    public int? CrashConsistentFrequencyInMinutes { get; set; }

    [JsonPropertyName("multiVmSyncStatus")]
    [Required]
    public SetMultiVMSyncStatusConstant MultiVMSyncStatus { get; set; }

    [JsonPropertyName("policyName")]
    [Required]
    public string PolicyName { get; set; }

    [JsonPropertyName("recoveryPointHistory")]
    public int? RecoveryPointHistory { get; set; }
}
