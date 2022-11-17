using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.UsageDetails;


internal class GenerateDetailedCostReportDefinitionModel
{
    [JsonPropertyName("billingPeriod")]
    public string? BillingPeriod { get; set; }

    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("invoiceId")]
    public string? InvoiceId { get; set; }

    [JsonPropertyName("metric")]
    public GenerateDetailedCostReportMetricTypeConstant? Metric { get; set; }

    [JsonPropertyName("timePeriod")]
    public GenerateDetailedCostReportTimePeriodModel? TimePeriod { get; set; }
}
