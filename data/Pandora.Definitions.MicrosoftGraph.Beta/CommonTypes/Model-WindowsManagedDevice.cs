// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsManagedDeviceModel
{
    [JsonPropertyName("aadRegistered")]
    public bool? AadRegistered { get; set; }

    [JsonPropertyName("activationLockBypassCode")]
    public string? ActivationLockBypassCode { get; set; }

    [JsonPropertyName("androidSecurityPatchLevel")]
    public string? AndroidSecurityPatchLevel { get; set; }

    [JsonPropertyName("assignmentFilterEvaluationStatusDetails")]
    public List<AssignmentFilterEvaluationStatusDetailsModel>? AssignmentFilterEvaluationStatusDetails { get; set; }

    [JsonPropertyName("autopilotEnrolled")]
    public bool? AutopilotEnrolled { get; set; }

    [JsonPropertyName("azureADDeviceId")]
    public string? AzureADDeviceId { get; set; }

    [JsonPropertyName("azureADRegistered")]
    public bool? AzureADRegistered { get; set; }

    [JsonPropertyName("azureActiveDirectoryDeviceId")]
    public string? AzureActiveDirectoryDeviceId { get; set; }

    [JsonPropertyName("bootstrapTokenEscrowed")]
    public bool? BootstrapTokenEscrowed { get; set; }

    [JsonPropertyName("chassisType")]
    public WindowsManagedDeviceChassisTypeConstant? ChassisType { get; set; }

    [JsonPropertyName("chromeOSDeviceInfo")]
    public List<ChromeOSDevicePropertyModel>? ChromeOSDeviceInfo { get; set; }

    [JsonPropertyName("cloudPcRemoteActionResults")]
    public List<CloudPCRemoteActionResultModel>? CloudPCRemoteActionResults { get; set; }

    [JsonPropertyName("complianceGracePeriodExpirationDateTime")]
    public DateTime? ComplianceGracePeriodExpirationDateTime { get; set; }

    [JsonPropertyName("complianceState")]
    public WindowsManagedDeviceComplianceStateConstant? ComplianceState { get; set; }

    [JsonPropertyName("configurationManagerClientEnabledFeatures")]
    public ConfigurationManagerClientEnabledFeaturesModel? ConfigurationManagerClientEnabledFeatures { get; set; }

    [JsonPropertyName("configurationManagerClientHealthState")]
    public ConfigurationManagerClientHealthStateModel? ConfigurationManagerClientHealthState { get; set; }

    [JsonPropertyName("configurationManagerClientInformation")]
    public ConfigurationManagerClientInformationModel? ConfigurationManagerClientInformation { get; set; }

    [JsonPropertyName("detectedApps")]
    public List<DetectedAppModel>? DetectedApps { get; set; }

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
    public WindowsManagedDeviceDeviceEnrollmentTypeConstant? DeviceEnrollmentType { get; set; }

    [JsonPropertyName("deviceFirmwareConfigurationInterfaceManaged")]
    public bool? DeviceFirmwareConfigurationInterfaceManaged { get; set; }

    [JsonPropertyName("deviceHealthAttestationState")]
    public DeviceHealthAttestationStateModel? DeviceHealthAttestationState { get; set; }

    [JsonPropertyName("deviceHealthScriptStates")]
    public List<DeviceHealthScriptPolicyStateModel>? DeviceHealthScriptStates { get; set; }

    [JsonPropertyName("deviceIdentityAttestationDetail")]
    public DeviceIdentityAttestationDetailModel? DeviceIdentityAttestationDetail { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("deviceRegistrationState")]
    public WindowsManagedDeviceDeviceRegistrationStateConstant? DeviceRegistrationState { get; set; }

    [JsonPropertyName("deviceType")]
    public WindowsManagedDeviceDeviceTypeConstant? DeviceType { get; set; }

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

    [JsonPropertyName("enrollmentProfileName")]
    public string? EnrollmentProfileName { get; set; }

    [JsonPropertyName("ethernetMacAddress")]
    public string? EthernetMacAddress { get; set; }

    [JsonPropertyName("exchangeAccessState")]
    public WindowsManagedDeviceExchangeAccessStateConstant? ExchangeAccessState { get; set; }

    [JsonPropertyName("exchangeAccessStateReason")]
    public WindowsManagedDeviceExchangeAccessStateReasonConstant? ExchangeAccessStateReason { get; set; }

    [JsonPropertyName("exchangeLastSuccessfulSyncDateTime")]
    public DateTime? ExchangeLastSuccessfulSyncDateTime { get; set; }

    [JsonPropertyName("freeStorageSpaceInBytes")]
    public int? FreeStorageSpaceInBytes { get; set; }

    [JsonPropertyName("hardwareInformation")]
    public HardwareInformationModel? HardwareInformation { get; set; }

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

    [JsonPropertyName("joinType")]
    public WindowsManagedDeviceJoinTypeConstant? JoinType { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("logCollectionRequests")]
    public List<DeviceLogCollectionResponseModel>? LogCollectionRequests { get; set; }

    [JsonPropertyName("lostModeState")]
    public WindowsManagedDeviceLostModeStateConstant? LostModeState { get; set; }

    [JsonPropertyName("managedDeviceMobileAppConfigurationStates")]
    public List<ManagedDeviceMobileAppConfigurationStateModel>? ManagedDeviceMobileAppConfigurationStates { get; set; }

    [JsonPropertyName("managedDeviceName")]
    public string? ManagedDeviceName { get; set; }

    [JsonPropertyName("managedDeviceOwnerType")]
    public WindowsManagedDeviceManagedDeviceOwnerTypeConstant? ManagedDeviceOwnerType { get; set; }

    [JsonPropertyName("managementAgent")]
    public WindowsManagedDeviceManagementAgentConstant? ManagementAgent { get; set; }

    [JsonPropertyName("managementCertificateExpirationDate")]
    public DateTime? ManagementCertificateExpirationDate { get; set; }

    [JsonPropertyName("managementFeatures")]
    public WindowsManagedDeviceManagementFeaturesConstant? ManagementFeatures { get; set; }

    [JsonPropertyName("managementState")]
    public WindowsManagedDeviceManagementStateConstant? ManagementState { get; set; }

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

    [JsonPropertyName("ownerType")]
    public WindowsManagedDeviceOwnerTypeConstant? OwnerType { get; set; }

    [JsonPropertyName("partnerReportedThreatState")]
    public WindowsManagedDevicePartnerReportedThreatStateConstant? PartnerReportedThreatState { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("physicalMemoryInBytes")]
    public int? PhysicalMemoryInBytes { get; set; }

    [JsonPropertyName("preferMdmOverGroupPolicyAppliedDateTime")]
    public DateTime? PreferMdmOverGroupPolicyAppliedDateTime { get; set; }

    [JsonPropertyName("processorArchitecture")]
    public WindowsManagedDeviceProcessorArchitectureConstant? ProcessorArchitecture { get; set; }

    [JsonPropertyName("remoteAssistanceSessionErrorDetails")]
    public string? RemoteAssistanceSessionErrorDetails { get; set; }

    [JsonPropertyName("remoteAssistanceSessionUrl")]
    public string? RemoteAssistanceSessionUrl { get; set; }

    [JsonPropertyName("requireUserEnrollmentApproval")]
    public bool? RequireUserEnrollmentApproval { get; set; }

    [JsonPropertyName("retireAfterDateTime")]
    public DateTime? RetireAfterDateTime { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("securityBaselineStates")]
    public List<SecurityBaselineStateModel>? SecurityBaselineStates { get; set; }

    [JsonPropertyName("securityPatchLevel")]
    public string? SecurityPatchLevel { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("skuFamily")]
    public string? SkuFamily { get; set; }

    [JsonPropertyName("skuNumber")]
    public int? SkuNumber { get; set; }

    [JsonPropertyName("specificationVersion")]
    public string? SpecificationVersion { get; set; }

    [JsonPropertyName("subscriberCarrier")]
    public string? SubscriberCarrier { get; set; }

    [JsonPropertyName("totalStorageSpaceInBytes")]
    public int? TotalStorageSpaceInBytes { get; set; }

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

    [JsonPropertyName("usersLoggedOn")]
    public List<LoggedOnUserModel>? UsersLoggedOn { get; set; }

    [JsonPropertyName("wiFiMacAddress")]
    public string? WiFiMacAddress { get; set; }

    [JsonPropertyName("windowsActiveMalwareCount")]
    public int? WindowsActiveMalwareCount { get; set; }

    [JsonPropertyName("windowsProtectionState")]
    public WindowsProtectionStateModel? WindowsProtectionState { get; set; }

    [JsonPropertyName("windowsRemediatedMalwareCount")]
    public int? WindowsRemediatedMalwareCount { get; set; }
}
