using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.AvailableSkus;


internal class DataBoxEdgeSkuModel
{
    [JsonPropertyName("apiVersions")]
    public List<string>? ApiVersions { get; set; }

    [JsonPropertyName("availability")]
    public SkuAvailabilityConstant? Availability { get; set; }

    [JsonPropertyName("capabilities")]
    public List<SkuCapabilityModel>? Capabilities { get; set; }

    [JsonPropertyName("costs")]
    public List<SkuCostModel>? Costs { get; set; }

    [JsonPropertyName("family")]
    public string? Family { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("locationInfo")]
    public List<SkuLocationInfoModel>? LocationInfo { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("name")]
    public SkuNameConstant? Name { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("shipmentTypes")]
    public List<ShipmentTypeConstant>? ShipmentTypes { get; set; }

    [JsonPropertyName("signupOption")]
    public SkuSignupOptionConstant? SignupOption { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("tier")]
    public SkuTierConstant? Tier { get; set; }

    [JsonPropertyName("version")]
    public SkuVersionConstant? Version { get; set; }
}
