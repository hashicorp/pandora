using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.Replicas;


internal class ServerPropertiesModel
{
    [JsonPropertyName("administratorLogin")]
    public string? AdministratorLogin { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("earliestRestoreDate")]
    public DateTime? EarliestRestoreDate { get; set; }

    [JsonPropertyName("fullyQualifiedDomainName")]
    public string? FullyQualifiedDomainName { get; set; }

    [JsonPropertyName("masterServerId")]
    public string? MasterServerId { get; set; }

    [JsonPropertyName("minimalTlsVersion")]
    public MinimalTlsVersionEnumConstant? MinimalTlsVersion { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<ServerPrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessEnumConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("replicaCapacity")]
    public int? ReplicaCapacity { get; set; }

    [JsonPropertyName("replicationRole")]
    public string? ReplicationRole { get; set; }

    [JsonPropertyName("sslEnforcement")]
    public SslEnforcementEnumConstant? SslEnforcement { get; set; }

    [JsonPropertyName("storageProfile")]
    public StorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("userVisibleState")]
    public ServerStateConstant? UserVisibleState { get; set; }

    [JsonPropertyName("version")]
    public ServerVersionConstant? Version { get; set; }
}
