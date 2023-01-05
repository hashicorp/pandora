using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.Servers;


internal class ServerPropertiesForUpdateModel
{
    [JsonPropertyName("administratorLoginPassword")]
    public string? AdministratorLoginPassword { get; set; }

    [JsonPropertyName("backup")]
    public BackupModel? Backup { get; set; }

    [JsonPropertyName("dataEncryption")]
    public DataEncryptionModel? DataEncryption { get; set; }

    [JsonPropertyName("highAvailability")]
    public HighAvailabilityModel? HighAvailability { get; set; }

    [JsonPropertyName("maintenanceWindow")]
    public MaintenanceWindowModel? MaintenanceWindow { get; set; }

    [JsonPropertyName("replicationRole")]
    public ReplicationRoleConstant? ReplicationRole { get; set; }

    [JsonPropertyName("storage")]
    public StorageModel? Storage { get; set; }

    [JsonPropertyName("version")]
    public ServerVersionConstant? Version { get; set; }
}
