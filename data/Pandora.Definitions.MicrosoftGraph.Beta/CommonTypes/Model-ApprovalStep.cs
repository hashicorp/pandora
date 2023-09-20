// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ApprovalStepModel
{
    [JsonPropertyName("assignedToMe")]
    public bool? AssignedToMe { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("justification")]
    public string? Justification { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reviewResult")]
    public string? ReviewResult { get; set; }

    [JsonPropertyName("reviewedBy")]
    public IdentityModel? ReviewedBy { get; set; }

    [JsonPropertyName("reviewedDateTime")]
    public DateTime? ReviewedDateTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
