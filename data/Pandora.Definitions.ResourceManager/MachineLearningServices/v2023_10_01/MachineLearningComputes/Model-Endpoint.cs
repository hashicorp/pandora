using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.MachineLearningComputes;


internal class EndpointModel
{
    [JsonPropertyName("hostIp")]
    public string? HostIP { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("protocol")]
    public ProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("published")]
    public int? Published { get; set; }

    [JsonPropertyName("target")]
    public int? Target { get; set; }
}
