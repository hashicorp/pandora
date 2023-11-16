using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.LocationBasedCapabilities;


internal class FlexibleServerCapabilityModel
{
    [JsonPropertyName("fastProvisioningSupported")]
    public FastProvisioningSupportedEnumConstant? FastProvisioningSupported { get; set; }

    [JsonPropertyName("geoBackupSupported")]
    public GeoBackupSupportedEnumConstant? GeoBackupSupported { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("onlineResizeSupported")]
    public OnlineResizeSupportedEnumConstant? OnlineResizeSupported { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("restricted")]
    public RestrictedEnumConstant? Restricted { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("storageAutoGrowthSupported")]
    public StorageAutoGrowthSupportedEnumConstant? StorageAutoGrowthSupported { get; set; }

    [JsonPropertyName("supportedFastProvisioningEditions")]
    public List<FastProvisioningEditionCapabilityModel>? SupportedFastProvisioningEditions { get; set; }

    [JsonPropertyName("supportedServerEditions")]
    public List<FlexibleServerEditionCapabilityModel>? SupportedServerEditions { get; set; }

    [JsonPropertyName("supportedServerVersions")]
    public List<ServerVersionCapabilityModel>? SupportedServerVersions { get; set; }

    [JsonPropertyName("zoneRedundantHaAndGeoBackupSupported")]
    public ZoneRedundantHaAndGeoBackupSupportedEnumConstant? ZoneRedundantHaAndGeoBackupSupported { get; set; }

    [JsonPropertyName("zoneRedundantHaSupported")]
    public ZoneRedundantHaSupportedEnumConstant? ZoneRedundantHaSupported { get; set; }
}
