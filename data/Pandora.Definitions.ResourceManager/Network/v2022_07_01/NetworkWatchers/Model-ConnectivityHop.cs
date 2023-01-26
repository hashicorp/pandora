using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;


internal class ConnectivityHopModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("issues")]
    public List<ConnectivityIssueModel>? Issues { get; set; }

    [JsonPropertyName("links")]
    public List<HopLinkModel>? Links { get; set; }

    [JsonPropertyName("nextHopIds")]
    public List<string>? NextHopIds { get; set; }

    [JsonPropertyName("previousHopIds")]
    public List<string>? PreviousHopIds { get; set; }

    [JsonPropertyName("previousLinks")]
    public List<HopLinkModel>? PreviousLinks { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
