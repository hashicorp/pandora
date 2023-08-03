// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RiskyServicePrincipalModel
{
    [JsonPropertyName("accountEnabled")]
    public bool? AccountEnabled { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("history")]
    public List<RiskyServicePrincipalHistoryItemModel>? History { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("isProcessing")]
    public bool? IsProcessing { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("riskDetail")]
    public RiskDetailConstant? RiskDetail { get; set; }

    [JsonPropertyName("riskLastUpdatedDateTime")]
    public DateTime? RiskLastUpdatedDateTime { get; set; }

    [JsonPropertyName("riskLevel")]
    public RiskLevelConstant? RiskLevel { get; set; }

    [JsonPropertyName("riskState")]
    public RiskStateConstant? RiskState { get; set; }

    [JsonPropertyName("servicePrincipalType")]
    public string? ServicePrincipalType { get; set; }
}
