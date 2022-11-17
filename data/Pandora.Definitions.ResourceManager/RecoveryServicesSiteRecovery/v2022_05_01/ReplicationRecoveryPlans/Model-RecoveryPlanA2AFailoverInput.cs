using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationRecoveryPlans;

[ValueForType("A2A")]
internal class RecoveryPlanA2AFailoverInputModel : RecoveryPlanProviderSpecificFailoverInputModel
{
    [JsonPropertyName("cloudServiceCreationOption")]
    public string? CloudServiceCreationOption { get; set; }

    [JsonPropertyName("multiVmSyncPointOption")]
    public MultiVmSyncPointOptionConstant? MultiVmSyncPointOption { get; set; }

    [JsonPropertyName("recoveryPointType")]
    [Required]
    public A2ARpRecoveryPointTypeConstant RecoveryPointType { get; set; }
}
