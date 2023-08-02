// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsAggregatedPolicyComplianceModel
{
    [JsonPropertyName("compliancePolicyId")]
    public string? CompliancePolicyId { get; set; }

    [JsonPropertyName("compliancePolicyName")]
    public string? CompliancePolicyName { get; set; }

    [JsonPropertyName("compliancePolicyPlatform")]
    public string? CompliancePolicyPlatform { get; set; }

    [JsonPropertyName("compliancePolicyType")]
    public string? CompliancePolicyType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastRefreshedDateTime")]
    public DateTime? LastRefreshedDateTime { get; set; }

    [JsonPropertyName("numberOfCompliantDevices")]
    public long? NumberOfCompliantDevices { get; set; }

    [JsonPropertyName("numberOfErrorDevices")]
    public long? NumberOfErrorDevices { get; set; }

    [JsonPropertyName("numberOfNonCompliantDevices")]
    public long? NumberOfNonCompliantDevices { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyModifiedDateTime")]
    public DateTime? PolicyModifiedDateTime { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
