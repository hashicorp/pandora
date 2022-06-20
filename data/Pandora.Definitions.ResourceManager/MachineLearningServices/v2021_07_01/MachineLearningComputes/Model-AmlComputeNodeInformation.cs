using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.MachineLearningComputes;


internal class AmlComputeNodeInformationModel
{
    [JsonPropertyName("nodeId")]
    public string? NodeId { get; set; }

    [JsonPropertyName("nodeState")]
    public NodeStateConstant? NodeState { get; set; }

    [JsonPropertyName("port")]
    public float? Port { get; set; }

    [JsonPropertyName("privateIpAddress")]
    public string? PrivateIpAddress { get; set; }

    [JsonPropertyName("publicIpAddress")]
    public string? PublicIpAddress { get; set; }

    [JsonPropertyName("runId")]
    public string? RunId { get; set; }
}
