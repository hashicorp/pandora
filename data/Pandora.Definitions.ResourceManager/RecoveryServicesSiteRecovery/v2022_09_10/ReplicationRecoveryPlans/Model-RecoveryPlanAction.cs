using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationRecoveryPlans;


internal class RecoveryPlanActionModel
{
    [JsonPropertyName("actionName")]
    [Required]
    public string ActionName { get; set; }

    [JsonPropertyName("customDetails")]
    [Required]
    public RecoveryPlanActionDetailsModel CustomDetails { get; set; }

    [JsonPropertyName("failoverDirections")]
    [Required]
    public List<PossibleOperationsDirectionsConstant> FailoverDirections { get; set; }

    [JsonPropertyName("failoverTypes")]
    [Required]
    public List<ReplicationProtectedItemOperationConstant> FailoverTypes { get; set; }
}
