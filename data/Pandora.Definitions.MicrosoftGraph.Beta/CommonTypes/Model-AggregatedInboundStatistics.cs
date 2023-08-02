// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AggregatedInboundStatisticsModel
{
    [JsonPropertyName("errors")]
    public int? Errors { get; set; }

    [JsonPropertyName("groups")]
    public int? Groups { get; set; }

    [JsonPropertyName("matchedPeopleByRole")]
    public List<IndustryDataRunRoleCountMetricModel>? MatchedPeopleByRole { get; set; }

    [JsonPropertyName("memberships")]
    public int? Memberships { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organizations")]
    public int? Organizations { get; set; }

    [JsonPropertyName("people")]
    public int? People { get; set; }

    [JsonPropertyName("unmatchedPeopleByRole")]
    public List<IndustryDataRunRoleCountMetricModel>? UnmatchedPeopleByRole { get; set; }

    [JsonPropertyName("warnings")]
    public int? Warnings { get; set; }
}
