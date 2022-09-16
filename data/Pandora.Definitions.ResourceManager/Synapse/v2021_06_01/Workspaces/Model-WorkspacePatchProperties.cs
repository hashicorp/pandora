using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.Workspaces;


internal class WorkspacePatchPropertiesModel
{
    [JsonPropertyName("encryption")]
    public EncryptionDetailsModel? Encryption { get; set; }

    [JsonPropertyName("managedVirtualNetworkSettings")]
    public ManagedVirtualNetworkSettingsModel? ManagedVirtualNetworkSettings { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public WorkspacePublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("purviewConfiguration")]
    public PurviewConfigurationModel? PurviewConfiguration { get; set; }

    [JsonPropertyName("sqlAdministratorLoginPassword")]
    public string? SqlAdministratorLoginPassword { get; set; }

    [JsonPropertyName("workspaceRepositoryConfiguration")]
    public WorkspaceRepositoryConfigurationModel? WorkspaceRepositoryConfiguration { get; set; }
}
