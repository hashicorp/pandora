// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ManagedDeviceModel
{
    [JsonPropertyName("activationLockBypassCode")]
    public string? ActivationLockBypassCode { get; set; }

    [JsonPropertyName("androidSecurityPatchLevel")]
    public string? AndroidSecurityPatchLevel { get; set; }

    [JsonPropertyName("azureADDeviceId")]
    public string? AzureADDeviceId { get; set; }

    [JsonPropertyName("azureADRegistered")]
    public bool? AzureADRegistered { get; set; }

    [JsonPropertyName("complianceGracePeriodExpirationDateTime")]
    public DateTime? ComplianceGracePeriodExpirationDateTime { get; set; }

    [JsonPropertyName("complianceState")]
    public ComplianceStateConstant? ComplianceState { get; set; }

    [JsonPropertyName("configurationManagerClientEnabledFeatures")]
    public ConfigurationManagerClientEnabledFeaturesModel? ConfigurationManagerClientEnabledFeatures { get; set; }

    [JsonPropertyName("deviceActionResults")]
    public List<DeviceActionResultModel>? DeviceActionResults { get; set; }

    [JsonPropertyName("deviceCategory")]
    public DeviceCategoryModel? DeviceCategory { get; set; }

    [JsonPropertyName("deviceCategoryDisplayName")]
    public string? DeviceCategoryDisplayName { get; set; }

    [JsonPropertyName("deviceCompliancePolicyStates")]
    public List<DeviceCompliancePolicyStateModel>? DeviceCompliancePolicyStates { get; set; }

    [JsonPropertyName("deviceConfigurationStates")]
    public List<DeviceConfigurationStateModel>? DeviceConfigurationStates { get; set; }

    [JsonPropertyName("deviceEnrollmentType")]
    public DeviceEnrollmentTypeConstant? DeviceEnrollmentType { get; set; }

    [JsonPropertyName("deviceHealthAttestationState")]
    public DeviceHealthAttestationStateModel? DeviceHealthAttestationState { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("deviceRegistrationState")]
    public DeviceRegistrationStateConstant? DeviceRegistrationState { get; set; }

    [JsonPropertyName("easActivated")]
    public bool? EasActivated { get; set; }

    [JsonPropertyName("easActivationDateTime")]
    public DateTime? EasActivationDateTime { get; set; }

    [JsonPropertyName("easDeviceId")]
    public string? EasDeviceId { get; set; }

    [JsonPropertyName("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("enrolledDateTime")]
    public DateTime? EnrolledDateTime { get; set; }

    [JsonPropertyName("ethernetMacAddress")]
    public string? EthernetMacAddress { get; set; }

    [JsonPropertyName("exchangeAccessState")]
    public DeviceManagementExchangeAccessStateConstant? ExchangeAccessState { get; set; }

    [JsonPropertyName("exchangeAccessStateReason")]
    public DeviceManagementExchangeAccessStateReasonConstant? ExchangeAccessStateReason { get; set; }

    [JsonPropertyName("exchangeLastSuccessfulSyncDateTime")]
    public DateTime? ExchangeLastSuccessfulSyncDateTime { get; set; }

    [JsonPropertyName("freeStorageSpaceInBytes")]
    public long? FreeStorageSpaceInBytes { get; set; }

    [JsonPropertyName("iccid")]
    public string? Iccid { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("imei")]
    public string? Imei { get; set; }

    [JsonPropertyName("isEncrypted")]
    public bool? IsEncrypted { get; set; }

    [JsonPropertyName("isSupervised")]
    public bool? IsSupervised { get; set; }

    [JsonPropertyName("jailBroken")]
    public string? JailBroken { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("managedDeviceName")]
    public string? ManagedDeviceName { get; set; }

    [JsonPropertyName("managedDeviceOwnerType")]
    public ManagedDeviceOwnerTypeConstant? ManagedDeviceOwnerType { get; set; }

    [JsonPropertyName("managementAgent")]
    public ManagementAgentTypeConstant? ManagementAgent { get; set; }

    [JsonPropertyName("managementCertificateExpirationDate")]
    public DateTime? ManagementCertificateExpirationDate { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("meid")]
    public string? Meid { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystem")]
    public string? OperatingSystem { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("partnerReportedThreatState")]
    public ManagedDevicePartnerReportedHealthStateConstant? PartnerReportedThreatState { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("physicalMemoryInBytes")]
    public long? PhysicalMemoryInBytes { get; set; }

    [JsonPropertyName("remoteAssistanceSessionErrorDetails")]
    public string? RemoteAssistanceSessionErrorDetails { get; set; }

    [JsonPropertyName("remoteAssistanceSessionUrl")]
    public string? RemoteAssistanceSessionUrl { get; set; }

    [JsonPropertyName("requireUserEnrollmentApproval")]
    public bool? RequireUserEnrollmentApproval { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("subscriberCarrier")]
    public string? SubscriberCarrier { get; set; }

    [JsonPropertyName("totalStorageSpaceInBytes")]
    public long? TotalStorageSpaceInBytes { get; set; }

    [JsonPropertyName("udid")]
    public string? Udid { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("users")]
    public List<UserModel>? Users { get; set; }

    [JsonPropertyName("wiFiMacAddress")]
    public string? WiFiMacAddress { get; set; }
}
