// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerPlanModel
{
    [JsonPropertyName("buckets")]
    public List<PlannerBucketModel>? Buckets { get; set; }

    [JsonPropertyName("container")]
    public PlannerPlanContainerModel? Container { get; set; }

    [JsonPropertyName("contexts")]
    public PlannerPlanContextCollectionModel? Contexts { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("creationSource")]
    public PlannerPlanCreationModel? CreationSource { get; set; }

    [JsonPropertyName("details")]
    public PlannerPlanDetailsModel? Details { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("sharedWithContainers")]
    public List<PlannerSharedWithContainerModel>? SharedWithContainers { get; set; }

    [JsonPropertyName("tasks")]
    public List<PlannerTaskModel>? Tasks { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
