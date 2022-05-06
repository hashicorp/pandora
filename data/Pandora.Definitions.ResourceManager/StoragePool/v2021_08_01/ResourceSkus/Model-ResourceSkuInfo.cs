using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.ResourceSkus;


internal class ResourceSkuInfoModel
{
    [JsonPropertyName("apiVersion")]
    public string? ApiVersion { get; set; }

    [JsonPropertyName("capabilities")]
    public List<ResourceSkuCapabilityModel>? Capabilities { get; set; }

    [JsonPropertyName("locationInfo")]
    public ResourceSkuLocationInfoModel? LocationInfo { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("restrictions")]
    public List<ResourceSkuRestrictionsModel>? Restrictions { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }
}
