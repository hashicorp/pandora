using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.MachineLearningComputes;


internal class VolumeDefinitionModel
{
    [JsonPropertyName("bind")]
    public BindOptionsModel? Bind { get; set; }

    [JsonPropertyName("consistency")]
    public string? Consistency { get; set; }

    [JsonPropertyName("readOnly")]
    public bool? ReadOnly { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("tmpfs")]
    public TmpfsOptionsModel? Tmpfs { get; set; }

    [JsonPropertyName("type")]
    public VolumeDefinitionTypeConstant? Type { get; set; }

    [JsonPropertyName("volume")]
    public VolumeOptionsModel? Volume { get; set; }
}
