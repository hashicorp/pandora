using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationNetworkMappings;


internal class CreateNetworkMappingInputPropertiesModel
{
    [JsonPropertyName("fabricSpecificDetails")]
    public FabricSpecificCreateNetworkMappingInputModel? FabricSpecificDetails { get; set; }

    [JsonPropertyName("recoveryFabricName")]
    public string? RecoveryFabricName { get; set; }

    [JsonPropertyName("recoveryNetworkId")]
    [Required]
    public string RecoveryNetworkId { get; set; }
}
