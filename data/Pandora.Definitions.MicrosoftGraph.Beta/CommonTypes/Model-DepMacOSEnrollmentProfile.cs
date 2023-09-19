// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DepMacOSEnrollmentProfileModel
{
    [JsonPropertyName("accessibilityScreenDisabled")]
    public bool? AccessibilityScreenDisabled { get; set; }

    [JsonPropertyName("adminAccountFullName")]
    public string? AdminAccountFullName { get; set; }

    [JsonPropertyName("adminAccountPassword")]
    public string? AdminAccountPassword { get; set; }

    [JsonPropertyName("adminAccountUserName")]
    public string? AdminAccountUserName { get; set; }

    [JsonPropertyName("appleIdDisabled")]
    public bool? AppleIdDisabled { get; set; }

    [JsonPropertyName("applePayDisabled")]
    public bool? ApplePayDisabled { get; set; }

    [JsonPropertyName("autoAdvanceSetupEnabled")]
    public bool? AutoAdvanceSetupEnabled { get; set; }

    [JsonPropertyName("autoUnlockWithWatchDisabled")]
    public bool? AutoUnlockWithWatchDisabled { get; set; }

    [JsonPropertyName("chooseYourLockScreenDisabled")]
    public bool? ChooseYourLockScreenDisabled { get; set; }

    [JsonPropertyName("configurationEndpointUrl")]
    public string? ConfigurationEndpointUrl { get; set; }

    [JsonPropertyName("configurationWebUrl")]
    public bool? ConfigurationWebUrl { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceNameTemplate")]
    public string? DeviceNameTemplate { get; set; }

    [JsonPropertyName("diagnosticsDisabled")]
    public bool? DiagnosticsDisabled { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("displayToneSetupDisabled")]
    public bool? DisplayToneSetupDisabled { get; set; }

    [JsonPropertyName("dontAutoPopulatePrimaryAccountInfo")]
    public bool? DontAutoPopulatePrimaryAccountInfo { get; set; }

    [JsonPropertyName("enableAuthenticationViaCompanyPortal")]
    public bool? EnableAuthenticationViaCompanyPortal { get; set; }

    [JsonPropertyName("enableRestrictEditing")]
    public bool? EnableRestrictEditing { get; set; }

    [JsonPropertyName("enabledSkipKeys")]
    public List<string>? EnabledSkipKeys { get; set; }

    [JsonPropertyName("enrollmentTimeAzureAdGroupIds")]
    public List<string>? EnrollmentTimeAzureAdGroupIds { get; set; }

    [JsonPropertyName("fileVaultDisabled")]
    public bool? FileVaultDisabled { get; set; }

    [JsonPropertyName("hideAdminAccount")]
    public bool? HideAdminAccount { get; set; }

    [JsonPropertyName("iCloudDiagnosticsDisabled")]
    public bool? ICloudDiagnosticsDisabled { get; set; }

    [JsonPropertyName("iCloudStorageDisabled")]
    public bool? ICloudStorageDisabled { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("isMandatory")]
    public bool? IsMandatory { get; set; }

    [JsonPropertyName("locationDisabled")]
    public bool? LocationDisabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passCodeDisabled")]
    public bool? PassCodeDisabled { get; set; }

    [JsonPropertyName("primaryAccountFullName")]
    public string? PrimaryAccountFullName { get; set; }

    [JsonPropertyName("primaryAccountUserName")]
    public string? PrimaryAccountUserName { get; set; }

    [JsonPropertyName("privacyPaneDisabled")]
    public bool? PrivacyPaneDisabled { get; set; }

    [JsonPropertyName("profileRemovalDisabled")]
    public bool? ProfileRemovalDisabled { get; set; }

    [JsonPropertyName("registrationDisabled")]
    public bool? RegistrationDisabled { get; set; }

    [JsonPropertyName("requestRequiresNetworkTether")]
    public bool? RequestRequiresNetworkTether { get; set; }

    [JsonPropertyName("requireCompanyPortalOnSetupAssistantEnrolledDevices")]
    public bool? RequireCompanyPortalOnSetupAssistantEnrolledDevices { get; set; }

    [JsonPropertyName("requiresUserAuthentication")]
    public bool? RequiresUserAuthentication { get; set; }

    [JsonPropertyName("restoreBlocked")]
    public bool? RestoreBlocked { get; set; }

    [JsonPropertyName("screenTimeScreenDisabled")]
    public bool? ScreenTimeScreenDisabled { get; set; }

    [JsonPropertyName("setPrimarySetupAccountAsRegularUser")]
    public bool? SetPrimarySetupAccountAsRegularUser { get; set; }

    [JsonPropertyName("siriDisabled")]
    public bool? SiriDisabled { get; set; }

    [JsonPropertyName("skipPrimarySetupAccountCreation")]
    public bool? SkipPrimarySetupAccountCreation { get; set; }

    [JsonPropertyName("supervisedModeEnabled")]
    public bool? SupervisedModeEnabled { get; set; }

    [JsonPropertyName("supportDepartment")]
    public string? SupportDepartment { get; set; }

    [JsonPropertyName("supportPhoneNumber")]
    public string? SupportPhoneNumber { get; set; }

    [JsonPropertyName("termsAndConditionsDisabled")]
    public bool? TermsAndConditionsDisabled { get; set; }

    [JsonPropertyName("touchIdDisabled")]
    public bool? TouchIdDisabled { get; set; }

    [JsonPropertyName("zoomDisabled")]
    public bool? ZoomDisabled { get; set; }
}
