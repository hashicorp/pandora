// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ChannelSummaryModel
{
    [JsonPropertyName("guestsCount")]
    public int? GuestsCount { get; set; }

    [JsonPropertyName("hasMembersFromOtherTenants")]
    public bool? HasMembersFromOtherTenants { get; set; }

    [JsonPropertyName("membersCount")]
    public int? MembersCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ownersCount")]
    public int? OwnersCount { get; set; }
}
