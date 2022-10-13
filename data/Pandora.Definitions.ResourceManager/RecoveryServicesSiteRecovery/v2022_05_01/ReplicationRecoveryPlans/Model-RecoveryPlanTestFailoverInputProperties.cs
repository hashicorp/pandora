using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationRecoveryPlans;


internal class RecoveryPlanTestFailoverInputPropertiesModel
{
    [JsonPropertyName("failoverDirection")]
    [Required]
    public PossibleOperationsDirectionsConstant FailoverDirection { get; set; }

    [JsonPropertyName("networkId")]
    public string? NetworkId { get; set; }

    [JsonPropertyName("networkType")]
    [Required]
    public string NetworkType { get; set; }

    [JsonPropertyName("providerSpecificDetails")]
    public List<RecoveryPlanProviderSpecificFailoverInputModel>? ProviderSpecificDetails { get; set; }
}
