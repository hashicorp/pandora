using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ValueForType("A2A")]
internal class A2AReprotectInputModel : ReverseReplicationProviderSpecificInputModel
{
    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("recoveryAvailabilitySetId")]
    public string? RecoveryAvailabilitySetId { get; set; }

    [JsonPropertyName("recoveryCloudServiceId")]
    public string? RecoveryCloudServiceId { get; set; }

    [JsonPropertyName("recoveryContainerId")]
    public string? RecoveryContainerId { get; set; }

    [JsonPropertyName("recoveryResourceGroupId")]
    public string? RecoveryResourceGroupId { get; set; }

    [JsonPropertyName("vmDisks")]
    public List<A2AVMDiskInputDetailsModel>? VMDisks { get; set; }
}
