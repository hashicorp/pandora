using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.AvailabilitySets;


internal class ResourceSkuModel
{
    [JsonPropertyName("apiVersions")]
    public List<string>? ApiVersions { get; set; }

    [JsonPropertyName("capabilities")]
    public List<ResourceSkuCapabilitiesModel>? Capabilities { get; set; }

    [JsonPropertyName("capacity")]
    public ResourceSkuCapacityModel? Capacity { get; set; }

    [JsonPropertyName("costs")]
    public List<ResourceSkuCostsModel>? Costs { get; set; }

    [JsonPropertyName("family")]
    public string? Family { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("locationInfo")]
    public List<ResourceSkuLocationInfoModel>? LocationInfo { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("restrictions")]
    public List<ResourceSkuRestrictionsModel>? Restrictions { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }
}
