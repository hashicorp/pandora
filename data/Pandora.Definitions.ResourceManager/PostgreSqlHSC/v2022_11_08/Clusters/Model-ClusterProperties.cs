using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Clusters;


internal class ClusterPropertiesModel
{
    [JsonPropertyName("administratorLogin")]
    public string? AdministratorLogin { get; set; }

    [JsonPropertyName("administratorLoginPassword")]
    public string? AdministratorLoginPassword { get; set; }

    [JsonPropertyName("citusVersion")]
    public string? CitusVersion { get; set; }

    [JsonPropertyName("coordinatorEnablePublicIpAccess")]
    public bool? CoordinatorEnablePublicIPAccess { get; set; }

    [JsonPropertyName("coordinatorServerEdition")]
    public string? CoordinatorServerEdition { get; set; }

    [JsonPropertyName("coordinatorStorageQuotaInMb")]
    public int? CoordinatorStorageQuotaInMb { get; set; }

    [JsonPropertyName("coordinatorVCores")]
    public int? CoordinatorVCores { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("earliestRestoreTime")]
    public DateTime? EarliestRestoreTime { get; set; }

    [JsonPropertyName("enableHa")]
    public bool? EnableHa { get; set; }

    [JsonPropertyName("enableShardsOnCoordinator")]
    public bool? EnableShardsOnCoordinator { get; set; }

    [JsonPropertyName("maintenanceWindow")]
    public MaintenanceWindowModel? MaintenanceWindow { get; set; }

    [JsonPropertyName("nodeCount")]
    public int? NodeCount { get; set; }

    [JsonPropertyName("nodeEnablePublicIpAccess")]
    public bool? NodeEnablePublicIPAccess { get; set; }

    [JsonPropertyName("nodeServerEdition")]
    public string? NodeServerEdition { get; set; }

    [JsonPropertyName("nodeStorageQuotaInMb")]
    public int? NodeStorageQuotaInMb { get; set; }

    [JsonPropertyName("nodeVCores")]
    public int? NodeVCores { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("pointInTimeUTC")]
    public DateTime? PointInTimeUTC { get; set; }

    [JsonPropertyName("postgresqlVersion")]
    public string? PostgresqlVersion { get; set; }

    [JsonPropertyName("preferredPrimaryZone")]
    public string? PreferredPrimaryZone { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<SimplePrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("readReplicas")]
    public List<string>? ReadReplicas { get; set; }

    [JsonPropertyName("serverNames")]
    public List<ServerNameItemModel>? ServerNames { get; set; }

    [JsonPropertyName("sourceLocation")]
    public string? SourceLocation { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}
