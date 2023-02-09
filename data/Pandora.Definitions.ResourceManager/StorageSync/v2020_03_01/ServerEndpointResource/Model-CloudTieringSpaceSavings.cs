using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;


internal class CloudTieringSpaceSavingsModel
{
    [JsonPropertyName("cachedSizeBytes")]
    public int? CachedSizeBytes { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTimestamp")]
    public DateTime? LastUpdatedTimestamp { get; set; }

    [JsonPropertyName("spaceSavingsBytes")]
    public int? SpaceSavingsBytes { get; set; }

    [JsonPropertyName("spaceSavingsPercent")]
    public int? SpaceSavingsPercent { get; set; }

    [JsonPropertyName("totalSizeCloudBytes")]
    public int? TotalSizeCloudBytes { get; set; }

    [JsonPropertyName("volumeSizeBytes")]
    public int? VolumeSizeBytes { get; set; }
}
