using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;


internal class IntegrationRuntimeComputePropertiesModel
{
    [JsonPropertyName("dataFlowProperties")]
    public IntegrationRuntimeDataFlowPropertiesModel? DataFlowProperties { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("maxParallelExecutionsPerNode")]
    public int? MaxParallelExecutionsPerNode { get; set; }

    [JsonPropertyName("nodeSize")]
    public string? NodeSize { get; set; }

    [JsonPropertyName("numberOfNodes")]
    public int? NumberOfNodes { get; set; }

    [JsonPropertyName("vNetProperties")]
    public IntegrationRuntimeVNetPropertiesModel? VNetProperties { get; set; }
}
