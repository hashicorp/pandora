using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Regions;


internal class VMSizeCompatibilityFilterV2Model
{
    [JsonPropertyName("clusterFlavors")]
    public List<string>? ClusterFlavors { get; set; }

    [JsonPropertyName("clusterVersions")]
    public List<string>? ClusterVersions { get; set; }

    [JsonPropertyName("computeIsolationSupported")]
    public string? ComputeIsolationSupported { get; set; }

    [JsonPropertyName("espApplied")]
    public string? EspApplied { get; set; }

    [JsonPropertyName("filterMode")]
    public FilterModeConstant? FilterMode { get; set; }

    [JsonPropertyName("nodeTypes")]
    public List<string>? NodeTypes { get; set; }

    [JsonPropertyName("osType")]
    public List<OSTypeConstant>? OsType { get; set; }

    [JsonPropertyName("regions")]
    public List<string>? Regions { get; set; }

    [JsonPropertyName("vmSizes")]
    public List<string>? VMSizes { get; set; }
}
