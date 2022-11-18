using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationRecoveryPlans;


internal class RecoveryPlanGroupModel
{
    [JsonPropertyName("endGroupActions")]
    public List<RecoveryPlanActionModel>? EndGroupActions { get; set; }

    [JsonPropertyName("groupType")]
    [Required]
    public RecoveryPlanGroupTypeConstant GroupType { get; set; }

    [JsonPropertyName("replicationProtectedItems")]
    public List<RecoveryPlanProtectedItemModel>? ReplicationProtectedItems { get; set; }

    [JsonPropertyName("startGroupActions")]
    public List<RecoveryPlanActionModel>? StartGroupActions { get; set; }
}
