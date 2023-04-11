using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.IoTSecuritySolutionsAnalytics;


internal class IoTSecurityAggregatedAlertPropertiesModel
{
    [JsonPropertyName("actionTaken")]
    public string? ActionTaken { get; set; }

    [JsonPropertyName("aggregatedDateUtc")]
    public string? AggregatedDateUtc { get; set; }

    [JsonPropertyName("alertDisplayName")]
    public string? AlertDisplayName { get; set; }

    [JsonPropertyName("alertType")]
    public string? AlertType { get; set; }

    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("effectedResourceType")]
    public string? EffectedResourceType { get; set; }

    [JsonPropertyName("logAnalyticsQuery")]
    public string? LogAnalyticsQuery { get; set; }

    [JsonPropertyName("remediationSteps")]
    public string? RemediationSteps { get; set; }

    [JsonPropertyName("reportedSeverity")]
    public ReportedSeverityConstant? ReportedSeverity { get; set; }

    [JsonPropertyName("systemSource")]
    public string? SystemSource { get; set; }

    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }
}
