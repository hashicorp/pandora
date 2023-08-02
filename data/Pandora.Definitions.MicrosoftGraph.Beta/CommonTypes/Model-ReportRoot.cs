// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ReportRootModel
{
    [JsonPropertyName("applicationSignInDetailedSummary")]
    public List<ApplicationSignInDetailedSummaryModel>? ApplicationSignInDetailedSummary { get; set; }

    [JsonPropertyName("authenticationMethods")]
    public AuthenticationMethodsRootModel? AuthenticationMethods { get; set; }

    [JsonPropertyName("credentialUserRegistrationDetails")]
    public List<CredentialUserRegistrationDetailsModel>? CredentialUserRegistrationDetails { get; set; }

    [JsonPropertyName("dailyPrintUsage")]
    public List<PrintUsageModel>? DailyPrintUsage { get; set; }

    [JsonPropertyName("dailyPrintUsageByPrinter")]
    public List<PrintUsageByPrinterModel>? DailyPrintUsageByPrinter { get; set; }

    [JsonPropertyName("dailyPrintUsageByUser")]
    public List<PrintUsageByUserModel>? DailyPrintUsageByUser { get; set; }

    [JsonPropertyName("dailyPrintUsageSummariesByPrinter")]
    public List<PrintUsageByPrinterModel>? DailyPrintUsageSummariesByPrinter { get; set; }

    [JsonPropertyName("dailyPrintUsageSummariesByUser")]
    public List<PrintUsageByUserModel>? DailyPrintUsageSummariesByUser { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("monthlyPrintUsageByPrinter")]
    public List<PrintUsageByPrinterModel>? MonthlyPrintUsageByPrinter { get; set; }

    [JsonPropertyName("monthlyPrintUsageByUser")]
    public List<PrintUsageByUserModel>? MonthlyPrintUsageByUser { get; set; }

    [JsonPropertyName("monthlyPrintUsageSummariesByPrinter")]
    public List<PrintUsageByPrinterModel>? MonthlyPrintUsageSummariesByPrinter { get; set; }

    [JsonPropertyName("monthlyPrintUsageSummariesByUser")]
    public List<PrintUsageByUserModel>? MonthlyPrintUsageSummariesByUser { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("security")]
    public SecurityReportsRootModel? Security { get; set; }

    [JsonPropertyName("userCredentialUsageDetails")]
    public List<UserCredentialUsageDetailsModel>? UserCredentialUsageDetails { get; set; }
}
