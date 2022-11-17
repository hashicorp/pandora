using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationNetworkMappings;


internal class NetworkMappingPropertiesModel
{
    [JsonPropertyName("fabricSpecificSettings")]
    public NetworkMappingFabricSpecificSettingsModel? FabricSpecificSettings { get; set; }

    [JsonPropertyName("primaryFabricFriendlyName")]
    public string? PrimaryFabricFriendlyName { get; set; }

    [JsonPropertyName("primaryNetworkFriendlyName")]
    public string? PrimaryNetworkFriendlyName { get; set; }

    [JsonPropertyName("primaryNetworkId")]
    public string? PrimaryNetworkId { get; set; }

    [JsonPropertyName("recoveryFabricArmId")]
    public string? RecoveryFabricArmId { get; set; }

    [JsonPropertyName("recoveryFabricFriendlyName")]
    public string? RecoveryFabricFriendlyName { get; set; }

    [JsonPropertyName("recoveryNetworkFriendlyName")]
    public string? RecoveryNetworkFriendlyName { get; set; }

    [JsonPropertyName("recoveryNetworkId")]
    public string? RecoveryNetworkId { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}
