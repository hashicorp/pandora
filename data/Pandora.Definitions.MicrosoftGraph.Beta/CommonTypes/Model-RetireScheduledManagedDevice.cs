// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RetireScheduledManagedDeviceModel
{
    [JsonPropertyName("complianceState")]
    public ComplianceStatusConstant? ComplianceState { get; set; }

    [JsonPropertyName("deviceCompliancePolicyId")]
    public string? DeviceCompliancePolicyId { get; set; }

    [JsonPropertyName("deviceCompliancePolicyName")]
    public string? DeviceCompliancePolicyName { get; set; }

    [JsonPropertyName("deviceType")]
    public DeviceTypeConstant? DeviceType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("managedDeviceName")]
    public string? ManagedDeviceName { get; set; }

    [JsonPropertyName("managementAgent")]
    public ManagementAgentTypeConstant? ManagementAgent { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ownerType")]
    public ManagedDeviceOwnerTypeConstant? OwnerType { get; set; }

    [JsonPropertyName("retireAfterDateTime")]
    public DateTime? RetireAfterDateTime { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }
}
