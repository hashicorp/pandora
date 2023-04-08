using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Applications;


internal class RoleModel
{
    [JsonPropertyName("autoscale")]
    public AutoscaleModel? Autoscale { get; set; }

    [JsonPropertyName("dataDisksGroups")]
    public List<DataDisksGroupsModel>? DataDisksGroups { get; set; }

    [JsonPropertyName("encryptDataDisks")]
    public bool? EncryptDataDisks { get; set; }

    [JsonPropertyName("hardwareProfile")]
    public HardwareProfileModel? HardwareProfile { get; set; }

    [JsonPropertyName("minInstanceCount")]
    public int? MinInstanceCount { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("osProfile")]
    public OsProfileModel? OsProfile { get; set; }

    [JsonPropertyName("scriptActions")]
    public List<ScriptActionModel>? ScriptActions { get; set; }

    [JsonPropertyName("targetInstanceCount")]
    public int? TargetInstanceCount { get; set; }

    [JsonPropertyName("VMGroupName")]
    public string? VMGroupName { get; set; }

    [JsonPropertyName("virtualNetworkProfile")]
    public VirtualNetworkProfileModel? VirtualNetworkProfile { get; set; }
}
