using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_03_01.ContainerInstance;


internal class DnsConfigurationModel
{
    [JsonPropertyName("nameServers")]
    [Required]
    public List<string> NameServers { get; set; }

    [JsonPropertyName("options")]
    public string? Options { get; set; }

    [JsonPropertyName("searchDomains")]
    public string? SearchDomains { get; set; }
}
