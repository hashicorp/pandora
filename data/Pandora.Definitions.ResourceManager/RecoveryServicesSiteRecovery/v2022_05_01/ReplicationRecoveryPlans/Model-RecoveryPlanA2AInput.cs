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
internal class RecoveryPlanA2AInputModel : RecoveryPlanProviderSpecificInputModel
{
    [JsonPropertyName("primaryExtendedLocation")]
    public CustomTypes.EdgeZone? PrimaryExtendedLocation { get; set; }

    [JsonPropertyName("primaryZone")]
    public string? PrimaryZone { get; set; }

    [JsonPropertyName("recoveryExtendedLocation")]
    public CustomTypes.EdgeZone? RecoveryExtendedLocation { get; set; }

    [JsonPropertyName("recoveryZone")]
    public string? RecoveryZone { get; set; }
}
