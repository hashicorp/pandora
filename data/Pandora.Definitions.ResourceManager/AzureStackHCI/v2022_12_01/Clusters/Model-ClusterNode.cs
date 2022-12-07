using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_12_01.Clusters;


internal class ClusterNodeModel
{
    [JsonPropertyName("coreCount")]
    public float? CoreCount { get; set; }

    [JsonPropertyName("EhcResourceId")]
    public string? EhcResourceId { get; set; }

    [JsonPropertyName("id")]
    public float? Id { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("memoryInGiB")]
    public float? MemoryInGiB { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("nodeType")]
    public ClusterNodeTypeConstant? NodeType { get; set; }

    [JsonPropertyName("osDisplayVersion")]
    public string? OsDisplayVersion { get; set; }

    [JsonPropertyName("osName")]
    public string? OsName { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("windowsServerSubscription")]
    public WindowsServerSubscriptionConstant? WindowsServerSubscription { get; set; }
}
