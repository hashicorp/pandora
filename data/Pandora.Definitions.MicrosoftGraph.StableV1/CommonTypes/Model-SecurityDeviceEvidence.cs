// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SecurityDeviceEvidenceModel
{
    [JsonPropertyName("azureAdDeviceId")]
    public string? AzureAdDeviceId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defenderAvStatus")]
    public DefenderAvStatusConstant? DefenderAvStatus { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("deviceDnsName")]
    public string? DeviceDnsName { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("healthStatus")]
    public DeviceHealthStatusConstant? HealthStatus { get; set; }

    [JsonPropertyName("ipInterfaces")]
    public List<string>? IpInterfaces { get; set; }

    [JsonPropertyName("loggedOnUsers")]
    public List<LoggedOnUserModel>? LoggedOnUsers { get; set; }

    [JsonPropertyName("mdeDeviceId")]
    public string? MdeDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onboardingStatus")]
    public OnboardingStatusConstant? OnboardingStatus { get; set; }

    [JsonPropertyName("osBuild")]
    public long? OsBuild { get; set; }

    [JsonPropertyName("osPlatform")]
    public string? OsPlatform { get; set; }

    [JsonPropertyName("rbacGroupId")]
    public int? RbacGroupId { get; set; }

    [JsonPropertyName("rbacGroupName")]
    public string? RbacGroupName { get; set; }

    [JsonPropertyName("remediationStatus")]
    public EvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("riskScore")]
    public DeviceRiskScoreConstant? RiskScore { get; set; }

    [JsonPropertyName("roles")]
    public List<EvidenceRoleConstant>? Roles { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("verdict")]
    public EvidenceVerdictConstant? Verdict { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("vmMetadata")]
    public VmMetadataModel? VmMetadata { get; set; }
}
