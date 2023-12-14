// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCModel
{
    [JsonPropertyName("aadDeviceId")]
    public string? AadDeviceId { get; set; }

    [JsonPropertyName("connectionSettings")]
    public CloudPCConnectionSettingsModel? ConnectionSettings { get; set; }

    [JsonPropertyName("connectivityResult")]
    public CloudPCConnectivityResultModel? ConnectivityResult { get; set; }

    [JsonPropertyName("diskEncryptionState")]
    public CloudPCDiskEncryptionStateConstant? DiskEncryptionState { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("gracePeriodEndDateTime")]
    public DateTime? GracePeriodEndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("imageDisplayName")]
    public string? ImageDisplayName { get; set; }

    [JsonPropertyName("lastLoginResult")]
    public CloudPCLoginResultModel? LastLoginResult { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lastRemoteActionResult")]
    public CloudPCRemoteActionResultModel? LastRemoteActionResult { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("managedDeviceName")]
    public string? ManagedDeviceName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesConnectionName")]
    public string? OnPremisesConnectionName { get; set; }

    [JsonPropertyName("osVersion")]
    public CloudPCOsVersionConstant? OsVersion { get; set; }

    [JsonPropertyName("partnerAgentInstallResults")]
    public List<CloudPCPartnerAgentInstallResultModel>? PartnerAgentInstallResults { get; set; }

    [JsonPropertyName("powerState")]
    public CloudPCPowerStateConstant? PowerState { get; set; }

    [JsonPropertyName("provisioningPolicyId")]
    public string? ProvisioningPolicyId { get; set; }

    [JsonPropertyName("provisioningPolicyName")]
    public string? ProvisioningPolicyName { get; set; }

    [JsonPropertyName("provisioningType")]
    public CloudPCProvisioningTypeConstant? ProvisioningType { get; set; }

    [JsonPropertyName("scopeIds")]
    public List<string>? ScopeIds { get; set; }

    [JsonPropertyName("servicePlanId")]
    public string? ServicePlanId { get; set; }

    [JsonPropertyName("servicePlanName")]
    public string? ServicePlanName { get; set; }

    [JsonPropertyName("servicePlanType")]
    public CloudPCServicePlanTypeConstant? ServicePlanType { get; set; }

    [JsonPropertyName("status")]
    public CloudPCStatusConstant? Status { get; set; }

    [JsonPropertyName("statusDetails")]
    public CloudPCStatusDetailsModel? StatusDetails { get; set; }

    [JsonPropertyName("userAccountType")]
    public CloudPCUserAccountTypeConstant? UserAccountType { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
