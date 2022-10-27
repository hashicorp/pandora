using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2020_10_05_privatepreview.ServerGroups;


internal class ServerGroupPropertiesForUpdateModel
{
    [JsonPropertyName("administratorLoginPassword")]
    public string? AdministratorLoginPassword { get; set; }

    [JsonPropertyName("availabilityZone")]
    public CustomTypes.Zone? AvailabilityZone { get; set; }

    [JsonPropertyName("backupRetentionDays")]
    public int? BackupRetentionDays { get; set; }

    [JsonPropertyName("citusVersion")]
    public CitusVersionConstant? CitusVersion { get; set; }

    [JsonPropertyName("enableShardsOnCoordinator")]
    public bool? EnableShardsOnCoordinator { get; set; }

    [JsonPropertyName("maintenanceWindow")]
    public MaintenanceWindowModel? MaintenanceWindow { get; set; }

    [JsonPropertyName("postgresqlVersion")]
    public PostgreSQLVersionConstant? PostgresqlVersion { get; set; }

    [MinItems(1)]
    [MaxItems(2)]
    [JsonPropertyName("serverRoleGroups")]
    public List<ServerRoleGroupModel>? ServerRoleGroups { get; set; }

    [JsonPropertyName("standbyAvailabilityZone")]
    public string? StandbyAvailabilityZone { get; set; }
}
