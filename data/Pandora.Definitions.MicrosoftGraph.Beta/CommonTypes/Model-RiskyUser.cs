// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RiskyUserModel
{
    [JsonPropertyName("history")]
    public List<RiskyUserHistoryItemModel>? History { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("isProcessing")]
    public bool? IsProcessing { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("riskDetail")]
    public RiskyUserRiskDetailConstant? RiskDetail { get; set; }

    [JsonPropertyName("riskLastUpdatedDateTime")]
    public DateTime? RiskLastUpdatedDateTime { get; set; }

    [JsonPropertyName("riskLevel")]
    public RiskyUserRiskLevelConstant? RiskLevel { get; set; }

    [JsonPropertyName("riskState")]
    public RiskyUserRiskStateConstant? RiskState { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
