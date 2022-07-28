using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkWatchers;


internal class NetworkSecurityRulesEvaluationResultModel
{
    [JsonPropertyName("destinationMatched")]
    public bool? DestinationMatched { get; set; }

    [JsonPropertyName("destinationPortMatched")]
    public bool? DestinationPortMatched { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("protocolMatched")]
    public bool? ProtocolMatched { get; set; }

    [JsonPropertyName("sourceMatched")]
    public bool? SourceMatched { get; set; }

    [JsonPropertyName("sourcePortMatched")]
    public bool? SourcePortMatched { get; set; }
}
