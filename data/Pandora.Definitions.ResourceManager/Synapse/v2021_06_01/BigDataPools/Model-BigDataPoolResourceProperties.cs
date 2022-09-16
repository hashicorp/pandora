using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.BigDataPools;


internal class BigDataPoolResourcePropertiesModel
{
    [JsonPropertyName("autoPause")]
    public AutoPausePropertiesModel? AutoPause { get; set; }

    [JsonPropertyName("autoScale")]
    public AutoScalePropertiesModel? AutoScale { get; set; }

    [JsonPropertyName("cacheSize")]
    public int? CacheSize { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("customLibraries")]
    public List<LibraryInfoModel>? CustomLibraries { get; set; }

    [JsonPropertyName("defaultSparkLogFolder")]
    public string? DefaultSparkLogFolder { get; set; }

    [JsonPropertyName("dynamicExecutorAllocation")]
    public DynamicExecutorAllocationModel? DynamicExecutorAllocation { get; set; }

    [JsonPropertyName("isAutotuneEnabled")]
    public bool? IsAutotuneEnabled { get; set; }

    [JsonPropertyName("isComputeIsolationEnabled")]
    public bool? IsComputeIsolationEnabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSucceededTimestamp")]
    public DateTime? LastSucceededTimestamp { get; set; }

    [JsonPropertyName("libraryRequirements")]
    public LibraryRequirementsModel? LibraryRequirements { get; set; }

    [JsonPropertyName("nodeCount")]
    public int? NodeCount { get; set; }

    [JsonPropertyName("nodeSize")]
    public NodeSizeConstant? NodeSize { get; set; }

    [JsonPropertyName("nodeSizeFamily")]
    public NodeSizeFamilyConstant? NodeSizeFamily { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("sessionLevelPackagesEnabled")]
    public bool? SessionLevelPackagesEnabled { get; set; }

    [JsonPropertyName("sparkConfigProperties")]
    public SparkConfigPropertiesModel? SparkConfigProperties { get; set; }

    [JsonPropertyName("sparkEventsFolder")]
    public string? SparkEventsFolder { get; set; }

    [JsonPropertyName("sparkVersion")]
    public string? SparkVersion { get; set; }
}
