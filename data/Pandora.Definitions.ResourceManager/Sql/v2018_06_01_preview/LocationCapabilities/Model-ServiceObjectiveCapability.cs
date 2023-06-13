using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.LocationCapabilities;


internal class ServiceObjectiveCapabilityModel
{
    [JsonPropertyName("computeModel")]
    public string? ComputeModel { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includedMaxSize")]
    public MaxSizeCapabilityModel? IncludedMaxSize { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("performanceLevel")]
    public PerformanceLevelCapabilityModel? PerformanceLevel { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("supportedAutoPauseDelay")]
    public AutoPauseDelayTimeRangeModel? SupportedAutoPauseDelay { get; set; }

    [JsonPropertyName("supportedLicenseTypes")]
    public List<LicenseTypeCapabilityModel>? SupportedLicenseTypes { get; set; }

    [JsonPropertyName("supportedMaxSizes")]
    public List<MaxSizeRangeCapabilityModel>? SupportedMaxSizes { get; set; }

    [JsonPropertyName("supportedMinCapacities")]
    public List<MinCapacityCapabilityModel>? SupportedMinCapacities { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
