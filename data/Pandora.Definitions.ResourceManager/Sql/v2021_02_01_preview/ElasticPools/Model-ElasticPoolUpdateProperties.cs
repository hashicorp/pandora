using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ElasticPools;


internal class ElasticPoolUpdatePropertiesModel
{
    [JsonPropertyName("licenseType")]
    public ElasticPoolLicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("maintenanceConfigurationId")]
    public string? MaintenanceConfigurationId { get; set; }

    [JsonPropertyName("maxSizeBytes")]
    public int? MaxSizeBytes { get; set; }

    [JsonPropertyName("perDatabaseSettings")]
    public ElasticPoolPerDatabaseSettingsModel? PerDatabaseSettings { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
