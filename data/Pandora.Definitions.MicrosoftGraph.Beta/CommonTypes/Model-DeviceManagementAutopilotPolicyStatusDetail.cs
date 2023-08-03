// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementAutopilotPolicyStatusDetailModel
{
    [JsonPropertyName("complianceStatus")]
    public DeviceManagementAutopilotPolicyComplianceStatusConstant? ComplianceStatus { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastReportedDateTime")]
    public DateTime? LastReportedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyType")]
    public DeviceManagementAutopilotPolicyTypeConstant? PolicyType { get; set; }

    [JsonPropertyName("trackedOnEnrollmentStatus")]
    public bool? TrackedOnEnrollmentStatus { get; set; }
}
