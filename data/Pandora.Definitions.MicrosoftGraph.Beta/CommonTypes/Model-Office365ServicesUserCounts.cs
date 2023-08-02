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
    public long? ExchangeActive { get; set; }

    [JsonPropertyName("exchangeInactive")]
    public long? ExchangeInactive { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("office365Active")]
    public long? Office365Active { get; set; }

    [JsonPropertyName("office365Inactive")]
    public long? Office365Inactive { get; set; }

    [JsonPropertyName("oneDriveActive")]
    public long? OneDriveActive { get; set; }

    [JsonPropertyName("oneDriveInactive")]
    public long? OneDriveInactive { get; set; }

    [JsonPropertyName("reportPeriod")]
    public string? ReportPeriod { get; set; }

    [JsonPropertyName("reportRefreshDate")]
    public DateTime? ReportRefreshDate { get; set; }

    [JsonPropertyName("sharePointActive")]
    public long? SharePointActive { get; set; }

    [JsonPropertyName("sharePointInactive")]
    public long? SharePointInactive { get; set; }

    [JsonPropertyName("skypeForBusinessActive")]
    public long? SkypeForBusinessActive { get; set; }

    [JsonPropertyName("skypeForBusinessInactive")]
    public long? SkypeForBusinessInactive { get; set; }

    [JsonPropertyName("teamsActive")]
    public long? TeamsActive { get; set; }

    [JsonPropertyName("teamsInactive")]
    public long? TeamsInactive { get; set; }

    [JsonPropertyName("yammerActive")]
    public long? YammerActive { get; set; }

    [JsonPropertyName("yammerInactive")]
    public long? YammerInactive { get; set; }
}
