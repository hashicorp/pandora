using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;


internal class ServerEndpointCloudTieringStatusModel
{
    [JsonPropertyName("cachePerformance")]
    public CloudTieringCachePerformanceModel? CachePerformance { get; set; }

    [JsonPropertyName("datePolicyStatus")]
    public CloudTieringDatePolicyStatusModel? DatePolicyStatus { get; set; }

    [JsonPropertyName("filesNotTiering")]
    public CloudTieringFilesNotTieringModel? FilesNotTiering { get; set; }

    [JsonPropertyName("health")]
    public ServerEndpointCloudTieringHealthStateConstant? Health { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("healthLastUpdatedTimestamp")]
    public DateTime? HealthLastUpdatedTimestamp { get; set; }

    [JsonPropertyName("lastCloudTieringResult")]
    public int? LastCloudTieringResult { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSuccessTimestamp")]
    public DateTime? LastSuccessTimestamp { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTimestamp")]
    public DateTime? LastUpdatedTimestamp { get; set; }

    [JsonPropertyName("spaceSavings")]
    public CloudTieringSpaceSavingsModel? SpaceSavings { get; set; }

    [JsonPropertyName("volumeFreeSpacePolicyStatus")]
    public CloudTieringVolumeFreeSpacePolicyStatusModel? VolumeFreeSpacePolicyStatus { get; set; }
}
