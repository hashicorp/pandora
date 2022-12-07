using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal abstract class CustomPersistentDiskPropertiesModel
{
    [JsonPropertyName("mountOptions")]
    public List<string>? MountOptions { get; set; }

    [JsonPropertyName("mountPath")]
    [Required]
    public string MountPath { get; set; }

    [JsonPropertyName("readOnly")]
    public bool? ReadOnly { get; set; }

    [JsonPropertyName("type")]
    [ProvidesTypeHint]
    [Required]
    public TypeConstant Type { get; set; }
}
