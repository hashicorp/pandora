using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;


internal class SkuCapacityModel
{
    [JsonPropertyName("allowedValues")]
    public List<int>? AllowedValues { get; set; }

    [JsonPropertyName("default")]
    public int? Default { get; set; }

    [JsonPropertyName("maximum")]
    public int? Maximum { get; set; }

    [JsonPropertyName("minimum")]
    public int? Minimum { get; set; }

    [JsonPropertyName("scaleType")]
    public ScaleTypeConstant? ScaleType { get; set; }
}
