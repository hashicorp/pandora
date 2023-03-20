using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.TaskRuns;


internal class OverrideTaskStepPropertiesModel
{
    [JsonPropertyName("arguments")]
    public List<ArgumentModel>? Arguments { get; set; }

    [JsonPropertyName("contextPath")]
    public string? ContextPath { get; set; }

    [JsonPropertyName("file")]
    public string? File { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("updateTriggerToken")]
    public string? UpdateTriggerToken { get; set; }

    [JsonPropertyName("values")]
    public List<SetValueModel>? Values { get; set; }
}
