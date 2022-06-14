using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.MachineLearningComputes;


internal class ComputeInstanceContainerModel
{
    [JsonPropertyName("autosave")]
    public AutosaveConstant? Autosave { get; set; }

    [JsonPropertyName("environment")]
    public ComputeInstanceEnvironmentInfoModel? Environment { get; set; }

    [JsonPropertyName("gpu")]
    public string? Gpu { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("network")]
    public NetworkConstant? Network { get; set; }

    [JsonPropertyName("services")]
    public List<object>? Services { get; set; }
}
