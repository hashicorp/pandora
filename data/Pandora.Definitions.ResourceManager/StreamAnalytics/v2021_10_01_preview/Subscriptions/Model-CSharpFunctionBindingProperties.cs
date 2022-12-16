using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;


internal class CSharpFunctionBindingPropertiesModel
{
    [JsonPropertyName("class")]
    public string? Class { get; set; }

    [JsonPropertyName("dllPath")]
    public string? DllPath { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("updateMode")]
    public UpdateModeConstant? UpdateMode { get; set; }
}
