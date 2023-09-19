// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserExperienceAnalyticsWorkFromAnywhereDeviceModel
{
    [JsonPropertyName("autoPilotProfileAssigned")]
    public bool? AutoPilotProfileAssigned { get; set; }

    [JsonPropertyName("autoPilotRegistered")]
    public bool? AutoPilotRegistered { get; set; }

    [JsonPropertyName("azureAdDeviceId")]
    public string? AzureAdDeviceId { get; set; }

    [JsonPropertyName("azureAdJoinType")]
    public string? AzureAdJoinType { get; set; }

    [JsonPropertyName("azureAdRegistered")]
    public bool? AzureAdRegistered { get; set; }

    [JsonPropertyName("compliancePolicySetToIntune")]
    public bool? CompliancePolicySetToIntune { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("healthStatus")]
    public UserExperienceAnalyticsWorkFromAnywhereDeviceHealthStatusConstant? HealthStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isCloudManagedGatewayEnabled")]
    public bool? IsCloudManagedGatewayEnabled { get; set; }

    [JsonPropertyName("managedBy")]
    public string? ManagedBy { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osCheckFailed")]
    public bool? OsCheckFailed { get; set; }

    [JsonPropertyName("osDescription")]
    public string? OsDescription { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("otherWorkloadsSetToIntune")]
    public bool? OtherWorkloadsSetToIntune { get; set; }

    [JsonPropertyName("ownership")]
    public string? Ownership { get; set; }

    [JsonPropertyName("processor64BitCheckFailed")]
    public bool? Processor64BitCheckFailed { get; set; }

    [JsonPropertyName("processorCoreCountCheckFailed")]
    public bool? ProcessorCoreCountCheckFailed { get; set; }

    [JsonPropertyName("processorFamilyCheckFailed")]
    public bool? ProcessorFamilyCheckFailed { get; set; }

    [JsonPropertyName("processorSpeedCheckFailed")]
    public bool? ProcessorSpeedCheckFailed { get; set; }

    [JsonPropertyName("ramCheckFailed")]
    public bool? RamCheckFailed { get; set; }

    [JsonPropertyName("secureBootCheckFailed")]
    public bool? SecureBootCheckFailed { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("storageCheckFailed")]
    public bool? StorageCheckFailed { get; set; }

    [JsonPropertyName("tenantAttached")]
    public bool? TenantAttached { get; set; }

    [JsonPropertyName("tpmCheckFailed")]
    public bool? TpmCheckFailed { get; set; }

    [JsonPropertyName("upgradeEligibility")]
    public UserExperienceAnalyticsWorkFromAnywhereDeviceUpgradeEligibilityConstant? UpgradeEligibility { get; set; }
}
