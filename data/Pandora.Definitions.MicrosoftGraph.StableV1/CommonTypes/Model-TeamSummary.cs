// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TeamSummaryModel
{
    [JsonPropertyName("guestsCount")]
    public int? GuestsCount { get; set; }

    [JsonPropertyName("membersCount")]
    public int? MembersCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ownersCount")]
    public int? OwnersCount { get; set; }
}
