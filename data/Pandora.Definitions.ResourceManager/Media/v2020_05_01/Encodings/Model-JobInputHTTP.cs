using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ValueForType("#Microsoft.Media.JobInputHttp")]
internal class JobInputHTTPModel : JobInputModel
{
    [JsonPropertyName("baseUri")]
    public string? BaseUri { get; set; }

    [JsonPropertyName("end")]
    public ClipTimeModel? End { get; set; }

    [JsonPropertyName("files")]
    public List<string>? Files { get; set; }

    [JsonPropertyName("inputDefinitions")]
    public List<InputDefinitionModel>? InputDefinitions { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("start")]
    public ClipTimeModel? Start { get; set; }
}
