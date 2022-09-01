using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts;


internal class AlertPropertiesDetailsModel
{
    [JsonPropertyName("amount")]
    public float? Amount { get; set; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("contactEmails")]
    public List<string>? ContactEmails { get; set; }

    [JsonPropertyName("contactGroups")]
    public List<string>? ContactGroups { get; set; }

    [JsonPropertyName("contactRoles")]
    public List<string>? ContactRoles { get; set; }

    [JsonPropertyName("currentSpend")]
    public float? CurrentSpend { get; set; }

    [JsonPropertyName("departmentName")]
    public string? DepartmentName { get; set; }

    [JsonPropertyName("enrollmentEndDate")]
    public string? EnrollmentEndDate { get; set; }

    [JsonPropertyName("enrollmentNumber")]
    public string? EnrollmentNumber { get; set; }

    [JsonPropertyName("enrollmentStartDate")]
    public string? EnrollmentStartDate { get; set; }

    [JsonPropertyName("invoicingThreshold")]
    public float? InvoicingThreshold { get; set; }

    [JsonPropertyName("meterFilter")]
    public List<object>? MeterFilter { get; set; }

    [JsonPropertyName("operator")]
    public AlertOperatorConstant? Operator { get; set; }

    [JsonPropertyName("overridingAlert")]
    public string? OverridingAlert { get; set; }

    [JsonPropertyName("periodStartDate")]
    public string? PeriodStartDate { get; set; }

    [JsonPropertyName("resourceFilter")]
    public List<object>? ResourceFilter { get; set; }

    [JsonPropertyName("resourceGroupFilter")]
    public List<object>? ResourceGroupFilter { get; set; }

    [JsonPropertyName("tagFilter")]
    public object? TagFilter { get; set; }

    [JsonPropertyName("threshold")]
    public float? Threshold { get; set; }

    [JsonPropertyName("timeGrainType")]
    public AlertTimeGrainTypeConstant? TimeGrainType { get; set; }

    [JsonPropertyName("triggeredBy")]
    public string? TriggeredBy { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}
