using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Nodes;


internal class NodePropertiesModel
{
    [JsonPropertyName("nodeChassisSerialNumber")]
    public string? NodeChassisSerialNumber { get; set; }

    [JsonPropertyName("nodeDisplayName")]
    public string? NodeDisplayName { get; set; }

    [JsonPropertyName("nodeFriendlySoftwareVersion")]
    public string? NodeFriendlySoftwareVersion { get; set; }

    [JsonPropertyName("nodeHcsVersion")]
    public string? NodeHcsVersion { get; set; }

    [JsonPropertyName("nodeInstanceId")]
    public string? NodeInstanceId { get; set; }

    [JsonPropertyName("nodeSerialNumber")]
    public string? NodeSerialNumber { get; set; }

    [JsonPropertyName("nodeStatus")]
    public NodeStatusConstant? NodeStatus { get; set; }
}
