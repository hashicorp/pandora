using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Operations;


internal class MetricSpecificationModel
{
    [JsonPropertyName("aggregationType")]
    public string? AggregationType { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("dimensions")]
    public List<DimensionModel>? Dimensions { get; set; }

    [JsonPropertyName("displayDescription")]
    public string? DisplayDescription { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fillGapWithZero")]
    public bool? FillGapWithZero { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resourceIdDimensionNameOverride")]
    public string? ResourceIdDimensionNameOverride { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}
