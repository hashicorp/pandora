using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectionContainers;


internal class ProtectionContainerPropertiesModel
{
    [JsonPropertyName("fabricFriendlyName")]
    public string? FabricFriendlyName { get; set; }

    [JsonPropertyName("fabricSpecificDetails")]
    public ProtectionContainerFabricSpecificDetailsModel? FabricSpecificDetails { get; set; }

    [JsonPropertyName("fabricType")]
    public string? FabricType { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("pairingStatus")]
    public string? PairingStatus { get; set; }

    [JsonPropertyName("protectedItemCount")]
    public int? ProtectedItemCount { get; set; }

    [JsonPropertyName("role")]
    public string? Role { get; set; }
}
