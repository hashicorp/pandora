using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.Topology;


internal class TopologySingleResourceModel
{
    [JsonPropertyName("children")]
    public List<TopologySingleResourceChildModel>? Children { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("networkZones")]
    public string? NetworkZones { get; set; }

    [JsonPropertyName("parents")]
    public List<TopologySingleResourceParentModel>? Parents { get; set; }

    [JsonPropertyName("recommendationsExist")]
    public bool? RecommendationsExist { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }

    [JsonPropertyName("topologyScore")]
    public int? TopologyScore { get; set; }
}
