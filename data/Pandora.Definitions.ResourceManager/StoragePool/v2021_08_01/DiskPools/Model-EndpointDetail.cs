using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools;


internal class EndpointDetailModel
{
    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("isAccessible")]
    public bool? IsAccessible { get; set; }

    [JsonPropertyName("latency")]
    public float? Latency { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }
}
