using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OperationalizationClusters;


internal class ScriptReferenceModel
{
    [JsonPropertyName("scriptArguments")]
    public string? ScriptArguments { get; set; }

    [JsonPropertyName("scriptData")]
    public string? ScriptData { get; set; }

    [JsonPropertyName("scriptSource")]
    public string? ScriptSource { get; set; }

    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }
}
