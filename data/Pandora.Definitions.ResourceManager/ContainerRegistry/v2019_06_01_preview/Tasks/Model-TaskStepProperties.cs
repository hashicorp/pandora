using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;


internal abstract class TaskStepPropertiesModel
{
    [JsonPropertyName("baseImageDependencies")]
    public List<BaseImageDependencyModel>? BaseImageDependencies { get; set; }

    [JsonPropertyName("contextAccessToken")]
    public string? ContextAccessToken { get; set; }

    [JsonPropertyName("contextPath")]
    public string? ContextPath { get; set; }

    [JsonPropertyName("type")]
    [ProvidesTypeHint]
    [Required]
    public StepTypeConstant Type { get; set; }
}
