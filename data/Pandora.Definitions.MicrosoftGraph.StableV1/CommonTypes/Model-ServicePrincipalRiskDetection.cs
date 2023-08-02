// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ServicePrincipalRiskDetectionModel
{
    [JsonPropertyName("activity")]
    public ActivityTypeConstant? Activity { get; set; }

    [JsonPropertyName("activityDateTime")]
    public DateTime? ActivityDateTime { get; set; }

    [JsonPropertyName("additionalInfo")]
    public string? AdditionalInfo { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("detectedDateTime")]
    public DateTime? DetectedDateTime { get; set; }

    [JsonPropertyName("detectionTimingType")]
    public RiskDetectionTimingTypeConstant? DetectionTimingType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("keyIds")]
    public List<string>? KeyIds { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("location")]
    public SignInLocationModel? Location { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("riskDetail")]
    public RiskDetailConstant? RiskDetail { get; set; }

    [JsonPropertyName("riskEventType")]
    public string? RiskEventType { get; set; }

    [JsonPropertyName("riskLevel")]
    public RiskLevelConstant? RiskLevel { get; set; }

    [JsonPropertyName("riskState")]
    public RiskStateConstant? RiskState { get; set; }

    [JsonPropertyName("servicePrincipalDisplayName")]
    public string? ServicePrincipalDisplayName { get; set; }

    [JsonPropertyName("servicePrincipalId")]
    public string? ServicePrincipalId { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("tokenIssuerType")]
    public TokenIssuerTypeConstant? TokenIssuerType { get; set; }
}
