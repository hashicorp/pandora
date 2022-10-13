using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;


internal class RequiredTrafficModel
{
    [JsonPropertyName("direction")]
    public TrafficDirectionConstant? Direction { get; set; }

    [JsonPropertyName("fqdns")]
    public List<string>? Fqdns { get; set; }

    [JsonPropertyName("ips")]
    public List<string>? IPs { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("protocol")]
    public string? Protocol { get; set; }
}
