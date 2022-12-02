using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2021_08_01.Vaults;


internal class VaultPropertiesModel
{
    [JsonPropertyName("encryption")]
    public VaultPropertiesEncryptionModel? Encryption { get; set; }

    [JsonPropertyName("moveDetails")]
    public VaultPropertiesMoveDetailsModel? MoveDetails { get; set; }

    [JsonPropertyName("moveState")]
    public ResourceMoveStateConstant? MoveState { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionVaultPropertiesModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("privateEndpointStateForBackup")]
    public VaultPrivateEndpointStateConstant? PrivateEndpointStateForBackup { get; set; }

    [JsonPropertyName("privateEndpointStateForSiteRecovery")]
    public VaultPrivateEndpointStateConstant? PrivateEndpointStateForSiteRecovery { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("upgradeDetails")]
    public UpgradeDetailsModel? UpgradeDetails { get; set; }
}
