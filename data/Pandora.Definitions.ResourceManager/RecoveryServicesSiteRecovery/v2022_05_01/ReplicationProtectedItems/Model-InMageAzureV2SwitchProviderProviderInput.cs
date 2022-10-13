using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ValueForType("InMageAzureV2")]
internal class InMageAzureV2SwitchProviderProviderInputModel : SwitchProviderProviderSpecificInputModel
{
    [JsonPropertyName("targetApplianceID")]
    [Required]
    public string TargetApplianceID { get; set; }

    [JsonPropertyName("targetFabricID")]
    [Required]
    public string TargetFabricID { get; set; }

    [JsonPropertyName("targetVaultID")]
    [Required]
    public string TargetVaultID { get; set; }
}
