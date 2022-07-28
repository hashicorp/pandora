using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkWatchers;


internal class HopLinkModel
{
    [JsonPropertyName("context")]
    public Dictionary<string, string>? Context { get; set; }

    [JsonPropertyName("issues")]
    public List<ConnectivityIssueModel>? Issues { get; set; }

    [JsonPropertyName("linkType")]
    public string? LinkType { get; set; }

    [JsonPropertyName("nextHopId")]
    public string? NextHopId { get; set; }

    [JsonPropertyName("properties")]
    public HopLinkPropertiesModel? Properties { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }
}
