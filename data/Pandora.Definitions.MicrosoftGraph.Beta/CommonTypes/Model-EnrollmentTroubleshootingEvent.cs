// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EnrollmentTroubleshootingEventModel
{
    [JsonPropertyName("additionalInformation")]
    public List<KeyValuePairModel>? AdditionalInformation { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("enrollmentType")]
    public EnrollmentTroubleshootingEventEnrollmentTypeConstant? EnrollmentType { get; set; }

    [JsonPropertyName("eventDateTime")]
    public DateTime? EventDateTime { get; set; }

    [JsonPropertyName("eventName")]
    public string? EventName { get; set; }

    [JsonPropertyName("failureCategory")]
    public EnrollmentTroubleshootingEventFailureCategoryConstant? FailureCategory { get; set; }

    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedDeviceIdentifier")]
    public string? ManagedDeviceIdentifier { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystem")]
    public string? OperatingSystem { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("troubleshootingErrorDetails")]
    public DeviceManagementTroubleshootingErrorDetailsModel? TroubleshootingErrorDetails { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
