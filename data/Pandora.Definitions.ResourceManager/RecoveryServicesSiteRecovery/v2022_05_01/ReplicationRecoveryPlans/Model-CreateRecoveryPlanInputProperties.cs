using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationRecoveryPlans;


internal class CreateRecoveryPlanInputPropertiesModel
{
    [JsonPropertyName("failoverDeploymentModel")]
    public FailoverDeploymentModelConstant? FailoverDeploymentModel { get; set; }

    [JsonPropertyName("groups")]
    [Required]
    public List<RecoveryPlanGroupModel> Groups { get; set; }

    [JsonPropertyName("primaryFabricId")]
    [Required]
    public string PrimaryFabricId { get; set; }

    [JsonPropertyName("providerSpecificInput")]
    public List<RecoveryPlanProviderSpecificInputModel>? ProviderSpecificInput { get; set; }

    [JsonPropertyName("recoveryFabricId")]
    [Required]
    public string RecoveryFabricId { get; set; }
}
