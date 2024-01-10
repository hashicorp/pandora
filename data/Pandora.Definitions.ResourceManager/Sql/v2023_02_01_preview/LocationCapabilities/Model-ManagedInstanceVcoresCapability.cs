using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.LocationCapabilities;


internal class ManagedInstanceVcoresCapabilityModel
{
    [JsonPropertyName("includedMaxSize")]
    public MaxSizeCapabilityModel? IncludedMaxSize { get; set; }

    [JsonPropertyName("includedStorageIOps")]
    public int? IncludedStorageIOps { get; set; }

    [JsonPropertyName("includedStorageThroughputMBps")]
    public int? IncludedStorageThroughputMBps { get; set; }

    [JsonPropertyName("instancePoolSupported")]
    public bool? InstancePoolSupported { get; set; }

    [JsonPropertyName("iopsIncludedValueOverrideFactorPerSelectedStorageGB")]
    public float? IopsIncludedValueOverrideFactorPerSelectedStorageGB { get; set; }

    [JsonPropertyName("iopsMinValueOverrideFactorPerSelectedStorageGB")]
    public float? IopsMinValueOverrideFactorPerSelectedStorageGB { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("standaloneSupported")]
    public bool? StandaloneSupported { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("supportedMaintenanceConfigurations")]
    public List<ManagedInstanceMaintenanceConfigurationCapabilityModel>? SupportedMaintenanceConfigurations { get; set; }

    [JsonPropertyName("supportedStorageIOps")]
    public MaxLimitRangeCapabilityModel? SupportedStorageIOps { get; set; }

    [JsonPropertyName("supportedStorageSizes")]
    public List<MaxSizeRangeCapabilityModel>? SupportedStorageSizes { get; set; }

    [JsonPropertyName("supportedStorageThroughputMBps")]
    public MaxLimitRangeCapabilityModel? SupportedStorageThroughputMBps { get; set; }

    [JsonPropertyName("throughputMBpsIncludedValueOverrideFactorPerSelectedStorageGB")]
    public float? ThroughputMBpsIncludedValueOverrideFactorPerSelectedStorageGB { get; set; }

    [JsonPropertyName("throughputMBpsMinValueOverrideFactorPerSelectedStorageGB")]
    public float? ThroughputMBpsMinValueOverrideFactorPerSelectedStorageGB { get; set; }

    [JsonPropertyName("value")]
    public int? Value { get; set; }
}
