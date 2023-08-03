// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceAppManagementModel
{
    [JsonPropertyName("androidManagedAppProtections")]
    public List<AndroidManagedAppProtectionModel>? AndroidManagedAppProtections { get; set; }

    [JsonPropertyName("defaultManagedAppProtections")]
    public List<DefaultManagedAppProtectionModel>? DefaultManagedAppProtections { get; set; }

    [JsonPropertyName("deviceAppManagementTasks")]
    public List<DeviceAppManagementTaskModel>? DeviceAppManagementTasks { get; set; }

    [JsonPropertyName("enterpriseCodeSigningCertificates")]
    public List<EnterpriseCodeSigningCertificateModel>? EnterpriseCodeSigningCertificates { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("iosLobAppProvisioningConfigurations")]
    public List<IosLobAppProvisioningConfigurationModel>? IosLobAppProvisioningConfigurations { get; set; }

    [JsonPropertyName("iosManagedAppProtections")]
    public List<IosManagedAppProtectionModel>? IosManagedAppProtections { get; set; }

    [JsonPropertyName("isEnabledForMicrosoftStoreForBusiness")]
    public bool? IsEnabledForMicrosoftStoreForBusiness { get; set; }

    [JsonPropertyName("managedAppPolicies")]
    public List<ManagedAppPolicyModel>? ManagedAppPolicies { get; set; }

    [JsonPropertyName("managedAppRegistrations")]
    public List<ManagedAppRegistrationModel>? ManagedAppRegistrations { get; set; }

    [JsonPropertyName("managedAppStatuses")]
    public List<ManagedAppStatusModel>? ManagedAppStatuses { get; set; }

    [JsonPropertyName("managedEBookCategories")]
    public List<ManagedEBookCategoryModel>? ManagedEBookCategories { get; set; }

    [JsonPropertyName("managedEBooks")]
    public List<ManagedEBookModel>? ManagedEBooks { get; set; }

    [JsonPropertyName("mdmWindowsInformationProtectionPolicies")]
    public List<MdmWindowsInformationProtectionPolicyModel>? MdmWindowsInformationProtectionPolicies { get; set; }

    [JsonPropertyName("microsoftStoreForBusinessLanguage")]
    public string? MicrosoftStoreForBusinessLanguage { get; set; }

    [JsonPropertyName("microsoftStoreForBusinessLastCompletedApplicationSyncTime")]
    public DateTime? MicrosoftStoreForBusinessLastCompletedApplicationSyncTime { get; set; }

    [JsonPropertyName("microsoftStoreForBusinessLastSuccessfulSyncDateTime")]
    public DateTime? MicrosoftStoreForBusinessLastSuccessfulSyncDateTime { get; set; }

    [JsonPropertyName("microsoftStoreForBusinessPortalSelection")]
    public MicrosoftStoreForBusinessPortalSelectionOptionsConstant? MicrosoftStoreForBusinessPortalSelection { get; set; }

    [JsonPropertyName("mobileAppCategories")]
    public List<MobileAppCategoryModel>? MobileAppCategories { get; set; }

    [JsonPropertyName("mobileAppConfigurations")]
    public List<ManagedDeviceMobileAppConfigurationModel>? MobileAppConfigurations { get; set; }

    [JsonPropertyName("mobileApps")]
    public List<MobileAppModel>? MobileApps { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policySets")]
    public List<PolicySetModel>? PolicySets { get; set; }

    [JsonPropertyName("symantecCodeSigningCertificate")]
    public SymantecCodeSigningCertificateModel? SymantecCodeSigningCertificate { get; set; }

    [JsonPropertyName("targetedManagedAppConfigurations")]
    public List<TargetedManagedAppConfigurationModel>? TargetedManagedAppConfigurations { get; set; }

    [JsonPropertyName("vppTokens")]
    public List<VppTokenModel>? VppTokens { get; set; }

    [JsonPropertyName("wdacSupplementalPolicies")]
    public List<WindowsDefenderApplicationControlSupplementalPolicyModel>? WdacSupplementalPolicies { get; set; }

    [JsonPropertyName("windowsInformationProtectionDeviceRegistrations")]
    public List<WindowsInformationProtectionDeviceRegistrationModel>? WindowsInformationProtectionDeviceRegistrations { get; set; }

    [JsonPropertyName("windowsInformationProtectionPolicies")]
    public List<WindowsInformationProtectionPolicyModel>? WindowsInformationProtectionPolicies { get; set; }

    [JsonPropertyName("windowsInformationProtectionWipeActions")]
    public List<WindowsInformationProtectionWipeActionModel>? WindowsInformationProtectionWipeActions { get; set; }

    [JsonPropertyName("windowsManagedAppProtections")]
    public List<WindowsManagedAppProtectionModel>? WindowsManagedAppProtections { get; set; }

    [JsonPropertyName("windowsManagementApp")]
    public WindowsManagementAppModel? WindowsManagementApp { get; set; }
}
