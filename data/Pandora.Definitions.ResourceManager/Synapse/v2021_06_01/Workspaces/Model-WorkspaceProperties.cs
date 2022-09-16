using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.Workspaces;


internal class WorkspacePropertiesModel
{
    [JsonPropertyName("adlaResourceId")]
    public string? AdlaResourceId { get; set; }

    [JsonPropertyName("azureADOnlyAuthentication")]
    public bool? AzureADOnlyAuthentication { get; set; }

    [JsonPropertyName("connectivityEndpoints")]
    public Dictionary<string, string>? ConnectivityEndpoints { get; set; }

    [JsonPropertyName("cspWorkspaceAdminProperties")]
    public CspWorkspaceAdminPropertiesModel? CspWorkspaceAdminProperties { get; set; }

    [JsonPropertyName("defaultDataLakeStorage")]
    public DataLakeStorageAccountDetailsModel? DefaultDataLakeStorage { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionDetailsModel? Encryption { get; set; }

    [JsonPropertyName("extraProperties")]
    public Dictionary<string, object>? ExtraProperties { get; set; }

    [JsonPropertyName("managedResourceGroupName")]
    public string? ManagedResourceGroupName { get; set; }

    [JsonPropertyName("managedVirtualNetwork")]
    public string? ManagedVirtualNetwork { get; set; }

    [JsonPropertyName("managedVirtualNetworkSettings")]
    public ManagedVirtualNetworkSettingsModel? ManagedVirtualNetworkSettings { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public WorkspacePublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("purviewConfiguration")]
    public PurviewConfigurationModel? PurviewConfiguration { get; set; }

    [JsonPropertyName("settings")]
    public Dictionary<string, object>? Settings { get; set; }

    [JsonPropertyName("sqlAdministratorLogin")]
    public string? SqlAdministratorLogin { get; set; }

    [JsonPropertyName("sqlAdministratorLoginPassword")]
    public string? SqlAdministratorLoginPassword { get; set; }

    [JsonPropertyName("trustedServiceBypassEnabled")]
    public bool? TrustedServiceBypassEnabled { get; set; }

    [JsonPropertyName("virtualNetworkProfile")]
    public VirtualNetworkProfileModel? VirtualNetworkProfile { get; set; }

    [JsonPropertyName("workspaceRepositoryConfiguration")]
    public WorkspaceRepositoryConfigurationModel? WorkspaceRepositoryConfiguration { get; set; }

    [JsonPropertyName("workspaceUID")]
    public string? WorkspaceUID { get; set; }
}
