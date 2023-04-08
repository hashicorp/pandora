using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01.Alerts;


internal class AlertPropertiesModel
{
    [JsonPropertyName("actionTaken")]
    public string? ActionTaken { get; set; }

    [JsonPropertyName("alertDisplayName")]
    public string? AlertDisplayName { get; set; }

    [JsonPropertyName("alertName")]
    public string? AlertName { get; set; }

    [JsonPropertyName("associatedResource")]
    public string? AssociatedResource { get; set; }

    [JsonPropertyName("canBeInvestigated")]
    public bool? CanBeInvestigated { get; set; }

    [JsonPropertyName("compromisedEntity")]
    public string? CompromisedEntity { get; set; }

    [JsonPropertyName("confidenceReasons")]
    public List<AlertConfidenceReasonModel>? ConfidenceReasons { get; set; }

    [JsonPropertyName("confidenceScore")]
    public float? ConfidenceScore { get; set; }

    [JsonPropertyName("correlationKey")]
    public string? CorrelationKey { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("detectedTimeUtc")]
    public DateTime? DetectedTimeUtc { get; set; }

    [JsonPropertyName("entities")]
    public List<AlertEntityModel>? Entities { get; set; }

    [JsonPropertyName("extendedProperties")]
    public object? ExtendedProperties { get; set; }

    [JsonPropertyName("instanceId")]
    public string? InstanceId { get; set; }

    [JsonPropertyName("isIncident")]
    public bool? IsIncident { get; set; }

    [JsonPropertyName("remediationSteps")]
    public string? RemediationSteps { get; set; }

    [JsonPropertyName("reportedSeverity")]
    public ReportedSeverityConstant? ReportedSeverity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("reportedTimeUtc")]
    public DateTime? ReportedTimeUtc { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("systemSource")]
    public string? SystemSource { get; set; }

    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }

    [JsonPropertyName("workspaceArmId")]
    public string? WorkspaceArmId { get; set; }
}
