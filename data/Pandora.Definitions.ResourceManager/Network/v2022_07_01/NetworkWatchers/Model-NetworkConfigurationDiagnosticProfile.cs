using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;


internal class NetworkConfigurationDiagnosticProfileModel
{
    [JsonPropertyName("destination")]
    [Required]
    public string Destination { get; set; }

    [JsonPropertyName("destinationPort")]
    [Required]
    public string DestinationPort { get; set; }

    [JsonPropertyName("direction")]
    [Required]
    public DirectionConstant Direction { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public string Protocol { get; set; }

    [JsonPropertyName("source")]
    [Required]
    public string Source { get; set; }
}
