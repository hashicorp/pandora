using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ConnectionMonitors;


internal class ConnectionMonitorTestGroupModel
{
    [JsonPropertyName("destinations")]
    [Required]
    public List<string> Destinations { get; set; }

    [JsonPropertyName("disable")]
    public bool? Disable { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("sources")]
    [Required]
    public List<string> Sources { get; set; }

    [JsonPropertyName("testConfigurations")]
    [Required]
    public List<string> TestConfigurations { get; set; }
}
