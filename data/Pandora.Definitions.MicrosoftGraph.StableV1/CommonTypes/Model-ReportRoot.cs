// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ReportRootModel
{
    [JsonPropertyName("dailyPrintUsageByPrinter")]
    public List<PrintUsageByPrinterModel>? DailyPrintUsageByPrinter { get; set; }

    [JsonPropertyName("dailyPrintUsageByUser")]
    public List<PrintUsageByUserModel>? DailyPrintUsageByUser { get; set; }

    [JsonPropertyName("monthlyPrintUsageByPrinter")]
    public List<PrintUsageByPrinterModel>? MonthlyPrintUsageByPrinter { get; set; }

    [JsonPropertyName("monthlyPrintUsageByUser")]
    public List<PrintUsageByUserModel>? MonthlyPrintUsageByUser { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("security")]
    public SecurityReportsRootModel? Security { get; set; }
}
