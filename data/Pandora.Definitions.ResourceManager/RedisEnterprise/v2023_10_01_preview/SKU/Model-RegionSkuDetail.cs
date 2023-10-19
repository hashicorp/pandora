using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.SKU;


internal class RegionSkuDetailModel
{
    [JsonPropertyName("locationInfo")]
    public LocationInfoModel? LocationInfo { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("skuDetails")]
    public SkuDetailModel? SkuDetails { get; set; }
}
