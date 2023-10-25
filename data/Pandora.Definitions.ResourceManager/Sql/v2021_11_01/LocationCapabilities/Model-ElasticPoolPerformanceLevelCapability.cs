using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.LocationCapabilities;


internal class ElasticPoolPerformanceLevelCapabilityModel
{
    [JsonPropertyName("includedMaxSize")]
    public MaxSizeCapabilityModel? IncludedMaxSize { get; set; }

    [JsonPropertyName("maxDatabaseCount")]
    public int? MaxDatabaseCount { get; set; }

    [JsonPropertyName("performanceLevel")]
    public PerformanceLevelCapabilityModel? PerformanceLevel { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("supportedLicenseTypes")]
    public List<LicenseTypeCapabilityModel>? SupportedLicenseTypes { get; set; }

    [JsonPropertyName("supportedMaintenanceConfigurations")]
    public List<MaintenanceConfigurationCapabilityModel>? SupportedMaintenanceConfigurations { get; set; }

    [JsonPropertyName("supportedMaxSizes")]
    public List<MaxSizeRangeCapabilityModel>? SupportedMaxSizes { get; set; }

    [JsonPropertyName("supportedPerDatabaseMaxPerformanceLevels")]
    public List<ElasticPoolPerDatabaseMaxPerformanceLevelCapabilityModel>? SupportedPerDatabaseMaxPerformanceLevels { get; set; }

    [JsonPropertyName("supportedPerDatabaseMaxSizes")]
    public List<MaxSizeRangeCapabilityModel>? SupportedPerDatabaseMaxSizes { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
