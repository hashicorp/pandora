// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Office365ActiveUserCountsModel
{
    [JsonPropertyName("exchange")]
    public int? Exchange { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("office365")]
    public int? Office365 { get; set; }

    [JsonPropertyName("oneDrive")]
    public int? OneDrive { get; set; }

    [JsonPropertyName("reportDate")]
    public DateTime? ReportDate { get; set; }

    [JsonPropertyName("reportPeriod")]
    public string? ReportPeriod { get; set; }

    [JsonPropertyName("reportRefreshDate")]
    public DateTime? ReportRefreshDate { get; set; }

    [JsonPropertyName("sharePoint")]
    public int? SharePoint { get; set; }

    [JsonPropertyName("skypeForBusiness")]
    public int? SkypeForBusiness { get; set; }

    [JsonPropertyName("teams")]
    public int? Teams { get; set; }

    [JsonPropertyName("yammer")]
    public int? Yammer { get; set; }
}
