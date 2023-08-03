// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OverallPrintUsageSummaryModel
{
    [JsonPropertyName("activePrintersCount")]
    public int? ActivePrintersCount { get; set; }

    [JsonPropertyName("activeUsersCount")]
    public int? ActiveUsersCount { get; set; }

    [JsonPropertyName("daysInPeriod")]
    public int? DaysInPeriod { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("topPrinters")]
    public List<PrinterUsageSummaryModel>? TopPrinters { get; set; }

    [JsonPropertyName("topUsers")]
    public List<UserPrintUsageSummaryModel>? TopUsers { get; set; }

    [JsonPropertyName("totalIncompleteJobs")]
    public int? TotalIncompleteJobs { get; set; }

    [JsonPropertyName("totalJobsProcessed")]
    public int? TotalJobsProcessed { get; set; }
}
