// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PermissionsCreepIndexDistributionModel
{
    [JsonPropertyName("authorizationSystem")]
    public AuthorizationSystemModel? AuthorizationSystem { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("highRiskProfile")]
    public RiskProfileModel? HighRiskProfile { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lowRiskProfile")]
    public RiskProfileModel? LowRiskProfile { get; set; }

    [JsonPropertyName("mediumRiskProfile")]
    public RiskProfileModel? MediumRiskProfile { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
