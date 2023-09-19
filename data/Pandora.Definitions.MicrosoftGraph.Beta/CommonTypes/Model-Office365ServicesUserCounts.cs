// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Office365ServicesUserCountsModel
{
    [JsonPropertyName("exchangeActive")]
    public int? ExchangeActive { get; set; }

    [JsonPropertyName("exchangeInactive")]
    public int? ExchangeInactive { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("office365Active")]
    public int? Office365Active { get; set; }

    [JsonPropertyName("office365Inactive")]
    public int? Office365Inactive { get; set; }

    [JsonPropertyName("oneDriveActive")]
    public int? OneDriveActive { get; set; }

    [JsonPropertyName("oneDriveInactive")]
    public int? OneDriveInactive { get; set; }

    [JsonPropertyName("reportPeriod")]
    public string? ReportPeriod { get; set; }

    [JsonPropertyName("reportRefreshDate")]
    public DateTime? ReportRefreshDate { get; set; }

    [JsonPropertyName("sharePointActive")]
    public int? SharePointActive { get; set; }

    [JsonPropertyName("sharePointInactive")]
    public int? SharePointInactive { get; set; }

    [JsonPropertyName("skypeForBusinessActive")]
    public int? SkypeForBusinessActive { get; set; }

    [JsonPropertyName("skypeForBusinessInactive")]
    public int? SkypeForBusinessInactive { get; set; }

    [JsonPropertyName("teamsActive")]
    public int? TeamsActive { get; set; }

    [JsonPropertyName("teamsInactive")]
    public int? TeamsInactive { get; set; }

    [JsonPropertyName("yammerActive")]
    public int? YammerActive { get; set; }

    [JsonPropertyName("yammerInactive")]
    public int? YammerInactive { get; set; }
}
