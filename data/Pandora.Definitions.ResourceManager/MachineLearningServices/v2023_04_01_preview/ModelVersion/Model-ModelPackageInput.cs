using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.ModelVersion;


internal class ModelPackageInputModel
{
    [JsonPropertyName("inputType")]
    [Required]
    public PackageInputTypeConstant InputType { get; set; }

    [JsonPropertyName("mode")]
    public PackageInputDeliveryModeConstant? Mode { get; set; }

    [JsonPropertyName("mountPath")]
    public string? MountPath { get; set; }

    [JsonPropertyName("path")]
    [Required]
    public PackageInputPathBaseModel Path { get; set; }
}
