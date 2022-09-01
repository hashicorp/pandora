using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.DedicatedHostGroups;


internal class DedicatedHostInstanceViewWithNameModel
{
    [JsonPropertyName("assetId")]
    public string? AssetId { get; set; }

    [JsonPropertyName("availableCapacity")]
    public DedicatedHostAvailableCapacityModel? AvailableCapacity { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("statuses")]
    public List<InstanceViewStatusModel>? Statuses { get; set; }
}
