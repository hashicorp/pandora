// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerUserModel
{
    [JsonPropertyName("all")]
    public List<PlannerDeltaModel>? All { get; set; }

    [JsonPropertyName("favoritePlanReferences")]
    public PlannerFavoritePlanReferenceCollectionModel? FavoritePlanReferences { get; set; }

    [JsonPropertyName("favoritePlans")]
    public List<PlannerPlanModel>? FavoritePlans { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("plans")]
    public List<PlannerPlanModel>? Plans { get; set; }

    [JsonPropertyName("recentPlanReferences")]
    public PlannerRecentPlanReferenceCollectionModel? RecentPlanReferences { get; set; }

    [JsonPropertyName("recentPlans")]
    public List<PlannerPlanModel>? RecentPlans { get; set; }

    [JsonPropertyName("rosterPlans")]
    public List<PlannerPlanModel>? RosterPlans { get; set; }

    [JsonPropertyName("tasks")]
    public List<PlannerTaskModel>? Tasks { get; set; }
}
