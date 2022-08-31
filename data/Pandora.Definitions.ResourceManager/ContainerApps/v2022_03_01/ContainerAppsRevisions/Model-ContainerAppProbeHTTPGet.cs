using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsRevisions;


internal class ContainerAppProbeHTTPGetModel
{
    [JsonPropertyName("httpHeaders")]
    public List<ContainerAppProbeHTTPGetHTTPHeadersInlinedModel>? HTTPHeaders { get; set; }

    [JsonPropertyName("host")]
    public string? Host { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("port")]
    [Required]
    public int Port { get; set; }

    [JsonPropertyName("scheme")]
    public SchemeConstant? Scheme { get; set; }
}
