// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IndustryDataInboundActivityResultsModel
{
    [JsonPropertyName("activityId")]
    public string? ActivityId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("errors")]
    public int? Errors { get; set; }

    [JsonPropertyName("groups")]
    public IndustryDataRunEntityCountMetricModel? Groups { get; set; }

    [JsonPropertyName("matchedPeopleByRole")]
    public List<IndustryDataRunRoleCountMetricModel>? MatchedPeopleByRole { get; set; }

    [JsonPropertyName("memberships")]
    public IndustryDataRunEntityCountMetricModel? Memberships { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organizations")]
    public IndustryDataRunEntityCountMetricModel? Organizations { get; set; }

    [JsonPropertyName("people")]
    public IndustryDataRunEntityCountMetricModel? People { get; set; }

    [JsonPropertyName("status")]
    public IndustryDataActivityStatusConstant? Status { get; set; }

    [JsonPropertyName("unmatchedPeopleByRole")]
    public List<IndustryDataRunRoleCountMetricModel>? UnmatchedPeopleByRole { get; set; }

    [JsonPropertyName("warnings")]
    public int? Warnings { get; set; }
}
