using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.ConnectedClusters;


internal class HybridConnectionConfigModel
{
    [JsonPropertyName("expirationTime")]
    public int? ExpirationTime { get; set; }

    [JsonPropertyName("hybridConnectionName")]
    public string? HybridConnectionName { get; set; }

    [JsonPropertyName("relay")]
    public string? Relay { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }
}
