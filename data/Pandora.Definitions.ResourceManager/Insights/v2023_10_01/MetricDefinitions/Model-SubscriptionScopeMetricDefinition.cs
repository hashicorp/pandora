using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.MetricDefinitions;


internal class SubscriptionScopeMetricDefinitionModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("dimensions")]
    public List<LocalizableStringModel>? Dimensions { get; set; }

    [JsonPropertyName("displayDescription")]
    public string? DisplayDescription { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDimensionRequired")]
    public bool? IsDimensionRequired { get; set; }

    [JsonPropertyName("metricAvailabilities")]
    public List<MetricAvailabilityModel>? MetricAvailabilities { get; set; }

    [JsonPropertyName("metricClass")]
    public MetricClassConstant? MetricClass { get; set; }

    [JsonPropertyName("name")]
    public LocalizableStringModel? Name { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("primaryAggregationType")]
    public MetricAggregationTypeConstant? PrimaryAggregationType { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("supportedAggregationTypes")]
    public List<MetricAggregationTypeConstant>? SupportedAggregationTypes { get; set; }

    [JsonPropertyName("unit")]
    public MetricUnitConstant? Unit { get; set; }
}
