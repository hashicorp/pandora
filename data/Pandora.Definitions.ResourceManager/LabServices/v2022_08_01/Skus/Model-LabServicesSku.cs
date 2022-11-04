using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Skus;


internal class LabServicesSkuModel
{
    [JsonPropertyName("capabilities")]
    public List<LabServicesSkuCapabilitiesModel>? Capabilities { get; set; }

    [JsonPropertyName("capacity")]
    public LabServicesSkuCapacityModel? Capacity { get; set; }

    [JsonPropertyName("costs")]
    public List<LabServicesSkuCostModel>? Costs { get; set; }

    [JsonPropertyName("family")]
    public string? Family { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("restrictions")]
    public List<LabServicesSkuRestrictionsModel>? Restrictions { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("tier")]
    public LabServicesSkuTierConstant? Tier { get; set; }
}
