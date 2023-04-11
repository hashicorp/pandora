using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.Alerts;


internal class AlertPropertiesModel
{
    [JsonPropertyName("alertDisplayName")]
    public string? AlertDisplayName { get; set; }

    [JsonPropertyName("alertType")]
    public string? AlertType { get; set; }

    [JsonPropertyName("alertUri")]
    public string? AlertUri { get; set; }

    [JsonPropertyName("compromisedEntity")]
    public string? CompromisedEntity { get; set; }

    [JsonPropertyName("correlationKey")]
    public string? CorrelationKey { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTimeUtc")]
    public DateTime? EndTimeUtc { get; set; }

    [JsonPropertyName("entities")]
    public List<AlertEntityModel>? Entities { get; set; }

    [JsonPropertyName("extendedLinks")]
    public List<Dictionary<string, string>>? ExtendedLinks { get; set; }

    [JsonPropertyName("extendedProperties")]
    public Dictionary<string, string>? ExtendedProperties { get; set; }

    [JsonPropertyName("intent")]
    public IntentConstant? Intent { get; set; }

    [JsonPropertyName("isIncident")]
    public bool? IsIncident { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("processingEndTimeUtc")]
    public DateTime? ProcessingEndTimeUtc { get; set; }

    [JsonPropertyName("productComponentName")]
    public string? ProductComponentName { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("remediationSteps")]
    public List<string>? RemediationSteps { get; set; }

    [JsonPropertyName("resourceIdentifiers")]
    public List<ResourceIdentifierModel>? ResourceIdentifiers { get; set; }

    [JsonPropertyName("severity")]
    public AlertSeverityConstant? Severity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTimeUtc")]
    public DateTime? StartTimeUtc { get; set; }

    [JsonPropertyName("status")]
    public AlertStatusConstant? Status { get; set; }

    [JsonPropertyName("systemAlertId")]
    public string? SystemAlertId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeGeneratedUtc")]
    public DateTime? TimeGeneratedUtc { get; set; }

    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }
}
