using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Skus;


internal class ApiManagementSkuModel
{
    [JsonPropertyName("apiVersions")]
    public List<string>? ApiVersions { get; set; }

    [JsonPropertyName("capabilities")]
    public List<ApiManagementSkuCapabilitiesModel>? Capabilities { get; set; }

    [JsonPropertyName("capacity")]
    public ApiManagementSkuCapacityModel? Capacity { get; set; }

    [JsonPropertyName("costs")]
    public List<ApiManagementSkuCostsModel>? Costs { get; set; }

    [JsonPropertyName("family")]
    public string? Family { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("locationInfo")]
    public List<ApiManagementSkuLocationInfoModel>? LocationInfo { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("restrictions")]
    public List<ApiManagementSkuRestrictionsModel>? Restrictions { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }
}
