using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Regions;


internal class VMSizeCompatibilityFilterModel
{
    [JsonPropertyName("ClusterFlavors")]
    public List<string>? ClusterFlavors { get; set; }

    [JsonPropertyName("ClusterVersions")]
    public List<string>? ClusterVersions { get; set; }

    [JsonPropertyName("ComputeIsolationSupported")]
    public string? ComputeIsolationSupported { get; set; }

    [JsonPropertyName("ESPApplied")]
    public string? ESPApplied { get; set; }

    [JsonPropertyName("FilterMode")]
    public string? FilterMode { get; set; }

    [JsonPropertyName("NodeTypes")]
    public List<string>? NodeTypes { get; set; }

    [JsonPropertyName("OsType")]
    public List<string>? OsType { get; set; }

    [JsonPropertyName("Regions")]
    public List<string>? Regions { get; set; }

    [JsonPropertyName("VMSizes")]
    public List<string>? VMSizes { get; set; }
}
