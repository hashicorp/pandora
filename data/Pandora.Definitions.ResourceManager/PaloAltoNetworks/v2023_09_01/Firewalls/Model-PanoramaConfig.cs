using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.Firewalls;


internal class PanoramaConfigModel
{
    [JsonPropertyName("cgName")]
    public string? CgName { get; set; }

    [JsonPropertyName("configString")]
    [Required]
    public string ConfigString { get; set; }

    [JsonPropertyName("dgName")]
    public string? DgName { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("panoramaServer")]
    public string? PanoramaServer { get; set; }

    [JsonPropertyName("panoramaServer2")]
    public string? PanoramaServer2 { get; set; }

    [JsonPropertyName("tplName")]
    public string? TplName { get; set; }

    [JsonPropertyName("vmAuthKey")]
    public string? VMAuthKey { get; set; }
}
