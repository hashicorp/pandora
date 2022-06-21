using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.OperationalizationClusters;


internal class NodeStateCountsModel
{
    [JsonPropertyName("idleNodeCount")]
    public int? IdleNodeCount { get; set; }

    [JsonPropertyName("leavingNodeCount")]
    public int? LeavingNodeCount { get; set; }

    [JsonPropertyName("preemptedNodeCount")]
    public int? PreemptedNodeCount { get; set; }

    [JsonPropertyName("preparingNodeCount")]
    public int? PreparingNodeCount { get; set; }

    [JsonPropertyName("runningNodeCount")]
    public int? RunningNodeCount { get; set; }

    [JsonPropertyName("unusableNodeCount")]
    public int? UnusableNodeCount { get; set; }
}
