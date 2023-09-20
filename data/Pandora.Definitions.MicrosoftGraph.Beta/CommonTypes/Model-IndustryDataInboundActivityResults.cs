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
    public IndustryDataIndustryDataRunEntityCountMetricModel? Groups { get; set; }

    [JsonPropertyName("matchedPeopleByRole")]
    public List<IndustryDataIndustryDataRunRoleCountMetricModel>? MatchedPeopleByRole { get; set; }

    [JsonPropertyName("memberships")]
    public IndustryDataIndustryDataRunEntityCountMetricModel? Memberships { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organizations")]
    public IndustryDataIndustryDataRunEntityCountMetricModel? Organizations { get; set; }

    [JsonPropertyName("people")]
    public IndustryDataIndustryDataRunEntityCountMetricModel? People { get; set; }

    [JsonPropertyName("status")]
    public IndustryDataInboundActivityResultsStatusConstant? Status { get; set; }

    [JsonPropertyName("unmatchedPeopleByRole")]
    public List<IndustryDataIndustryDataRunRoleCountMetricModel>? UnmatchedPeopleByRole { get; set; }

    [JsonPropertyName("warnings")]
    public int? Warnings { get; set; }
}
