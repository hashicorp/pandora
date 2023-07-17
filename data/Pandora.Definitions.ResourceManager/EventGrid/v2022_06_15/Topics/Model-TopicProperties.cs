using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Topics;


internal class TopicPropertiesModel
{
    [JsonPropertyName("dataResidencyBoundary")]
    public DataResidencyBoundaryConstant? DataResidencyBoundary { get; set; }

    [JsonPropertyName("disableLocalAuth")]
    public bool? DisableLocalAuth { get; set; }

    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("inboundIpRules")]
    public List<InboundIPRuleModel>? InboundIPRules { get; set; }

    [JsonPropertyName("inputSchema")]
    public InputSchemaConstant? InputSchema { get; set; }

    [JsonPropertyName("inputSchemaMapping")]
    public InputSchemaMappingModel? InputSchemaMapping { get; set; }

    [JsonPropertyName("metricResourceId")]
    public string? MetricResourceId { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public TopicProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }
}
