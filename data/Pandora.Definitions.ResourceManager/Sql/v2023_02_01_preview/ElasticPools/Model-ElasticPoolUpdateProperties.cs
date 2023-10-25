using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ElasticPools;


internal class ElasticPoolUpdatePropertiesModel
{
    [JsonPropertyName("availabilityZone")]
    public AvailabilityZoneTypeConstant? AvailabilityZone { get; set; }

    [JsonPropertyName("highAvailabilityReplicaCount")]
    public int? HighAvailabilityReplicaCount { get; set; }

    [JsonPropertyName("licenseType")]
    public ElasticPoolLicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("maintenanceConfigurationId")]
    public string? MaintenanceConfigurationId { get; set; }

    [JsonPropertyName("maxSizeBytes")]
    public int? MaxSizeBytes { get; set; }

    [JsonPropertyName("minCapacity")]
    public float? MinCapacity { get; set; }

    [JsonPropertyName("perDatabaseSettings")]
    public ElasticPoolPerDatabaseSettingsModel? PerDatabaseSettings { get; set; }

    [JsonPropertyName("preferredEnclaveType")]
    public AlwaysEncryptedEnclaveTypeConstant? PreferredEnclaveType { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
