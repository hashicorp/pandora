using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_01.ManagedClusters;


internal class ManagedClusterHTTPProxyConfigModel
{
    [JsonPropertyName("httpProxy")]
    public string? HTTPProxy { get; set; }

    [JsonPropertyName("httpsProxy")]
    public string? HTTPSProxy { get; set; }

    [JsonPropertyName("noProxy")]
    public List<string>? NoProxy { get; set; }

    [JsonPropertyName("trustedCa")]
    public string? TrustedCa { get; set; }
}
