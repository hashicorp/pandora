using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.PublishedArtifact;


internal class ParameterValueModel
{
    [JsonPropertyName("reference")]
    public SecretValueReferenceModel? Reference { get; set; }

    [JsonPropertyName("value")]
    public object? Value { get; set; }
}
