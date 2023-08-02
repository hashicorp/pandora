// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PlannerModel
{
    [JsonPropertyName("buckets")]
    public List<PlannerBucketModel>? Buckets { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("plans")]
    public List<PlannerPlanModel>? Plans { get; set; }

    [JsonPropertyName("tasks")]
    public List<PlannerTaskModel>? Tasks { get; set; }
}
