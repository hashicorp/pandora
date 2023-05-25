using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.Servers;


internal class ServerPropertiesModel
{
    [JsonPropertyName("administratorLogin")]
    public string? AdministratorLogin { get; set; }

    [JsonPropertyName("administratorLoginPassword")]
    public string? AdministratorLoginPassword { get; set; }

    [JsonPropertyName("administrators")]
    public ServerExternalAdministratorModel? Administrators { get; set; }

    [JsonPropertyName("externalGovernanceStatus")]
    public ExternalGovernanceStatusConstant? ExternalGovernanceStatus { get; set; }

    [JsonPropertyName("federatedClientId")]
    public string? FederatedClientId { get; set; }

    [JsonPropertyName("fullyQualifiedDomainName")]
    public string? FullyQualifiedDomainName { get; set; }

    [JsonPropertyName("keyId")]
    public string? KeyId { get; set; }

    [JsonPropertyName("minimalTlsVersion")]
    public string? MinimalTlsVersion { get; set; }

    [JsonPropertyName("primaryUserAssignedIdentityId")]
    public string? PrimaryUserAssignedIdentityId { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<ServerPrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public ServerPublicNetworkAccessFlagConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("restrictOutboundNetworkAccess")]
    public ServerNetworkAccessFlagConstant? RestrictOutboundNetworkAccess { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("workspaceFeature")]
    public ServerWorkspaceFeatureConstant? WorkspaceFeature { get; set; }
}
