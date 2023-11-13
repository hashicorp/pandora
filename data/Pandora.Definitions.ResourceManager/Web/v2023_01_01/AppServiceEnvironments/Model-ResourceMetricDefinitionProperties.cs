using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceEnvironments;


internal class ResourceMetricDefinitionPropertiesModel
{
    [JsonPropertyName("metricAvailabilities")]
    public List<ResourceMetricAvailabilityModel>? MetricAvailabilities { get; set; }

    [JsonPropertyName("primaryAggregationType")]
    public string? PrimaryAggregationType { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("resourceUri")]
    public string? ResourceUri { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}
