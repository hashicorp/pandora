using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.Volumes;


internal class VolumePatchPropertiesModel
{
    [JsonPropertyName("dataProtection")]
    public VolumePatchPropertiesDataProtectionModel? DataProtection { get; set; }

    [JsonPropertyName("defaultGroupQuotaInKiBs")]
    public int? DefaultGroupQuotaInKiBs { get; set; }

    [JsonPropertyName("defaultUserQuotaInKiBs")]
    public int? DefaultUserQuotaInKiBs { get; set; }

    [JsonPropertyName("exportPolicy")]
    public VolumePatchPropertiesExportPolicyModel? ExportPolicy { get; set; }

    [JsonPropertyName("isDefaultQuotaEnabled")]
    public bool? IsDefaultQuotaEnabled { get; set; }

    [JsonPropertyName("serviceLevel")]
    public ServiceLevelConstant? ServiceLevel { get; set; }

    [JsonPropertyName("throughputMibps")]
    public float? ThroughputMibps { get; set; }

    [JsonPropertyName("unixPermissions")]
    public string? UnixPermissions { get; set; }

    [JsonPropertyName("usageThreshold")]
    public int? UsageThreshold { get; set; }
}
