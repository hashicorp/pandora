using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationRecoveryPlans;

[ValueForType("InMageAzureV2")]
internal class RecoveryPlanInMageAzureV2FailoverInputModel : RecoveryPlanProviderSpecificFailoverInputModel
{
    [JsonPropertyName("recoveryPointType")]
    [Required]
    public InMageV2RpRecoveryPointTypeConstant RecoveryPointType { get; set; }

    [JsonPropertyName("useMultiVmSyncPoint")]
    public string? UseMultiVmSyncPoint { get; set; }
}
