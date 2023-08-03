// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DepIOSEnrollmentProfileModel
{
    [JsonPropertyName("appearanceScreenDisabled")]
    public bool? AppearanceScreenDisabled { get; set; }

    [JsonPropertyName("appleIdDisabled")]
    public bool? AppleIdDisabled { get; set; }

    [JsonPropertyName("applePayDisabled")]
    public bool? ApplePayDisabled { get; set; }

    [JsonPropertyName("awaitDeviceConfiguredConfirmation")]
    public bool? AwaitDeviceConfiguredConfirmation { get; set; }

    [JsonPropertyName("carrierActivationUrl")]
    public string? CarrierActivationUrl { get; set; }

    [JsonPropertyName("companyPortalVppTokenId")]
    public string? CompanyPortalVppTokenId { get; set; }

    [JsonPropertyName("configurationEndpointUrl")]
    public string? ConfigurationEndpointUrl { get; set; }

    [JsonPropertyName("configurationWebUrl")]
    public bool? ConfigurationWebUrl { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceNameTemplate")]
    public string? DeviceNameTemplate { get; set; }

    [JsonPropertyName("deviceToDeviceMigrationDisabled")]
    public bool? DeviceToDeviceMigrationDisabled { get; set; }

    [JsonPropertyName("diagnosticsDisabled")]
    public bool? DiagnosticsDisabled { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("displayToneSetupDisabled")]
    public bool? DisplayToneSetupDisabled { get; set; }

    [JsonPropertyName("enableAuthenticationViaCompanyPortal")]
    public bool? EnableAuthenticationViaCompanyPortal { get; set; }

    [JsonPropertyName("enableSharedIPad")]
    public bool? EnableSharedIPad { get; set; }

    [JsonPropertyName("enableSingleAppEnrollmentMode")]
    public bool? EnableSingleAppEnrollmentMode { get; set; }

    [JsonPropertyName("enabledSkipKeys")]
    public List<string>? EnabledSkipKeys { get; set; }

    [JsonPropertyName("expressLanguageScreenDisabled")]
    public bool? ExpressLanguageScreenDisabled { get; set; }

    [JsonPropertyName("forceTemporarySession")]
    public bool? ForceTemporarySession { get; set; }

    [JsonPropertyName("homeButtonScreenDisabled")]
    public bool? HomeButtonScreenDisabled { get; set; }

    [JsonPropertyName("iMessageAndFaceTimeScreenDisabled")]
    public bool? IMessageAndFaceTimeScreenDisabled { get; set; }

    [JsonPropertyName("iTunesPairingMode")]
    public ITunesPairingModeConstant? ITunesPairingMode { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("isMandatory")]
    public bool? IsMandatory { get; set; }

    [JsonPropertyName("locationDisabled")]
    public bool? LocationDisabled { get; set; }

    [JsonPropertyName("managementCertificates")]
    public List<ManagementCertificateWithThumbprintModel>? ManagementCertificates { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onBoardingScreenDisabled")]
    public bool? OnBoardingScreenDisabled { get; set; }

    [JsonPropertyName("passCodeDisabled")]
    public bool? PassCodeDisabled { get; set; }

    [JsonPropertyName("passcodeLockGracePeriodInSeconds")]
    public int? PasscodeLockGracePeriodInSeconds { get; set; }

    [JsonPropertyName("preferredLanguageScreenDisabled")]
    public bool? PreferredLanguageScreenDisabled { get; set; }

    [JsonPropertyName("privacyPaneDisabled")]
    public bool? PrivacyPaneDisabled { get; set; }

    [JsonPropertyName("profileRemovalDisabled")]
    public bool? ProfileRemovalDisabled { get; set; }

    [JsonPropertyName("requireCompanyPortalOnSetupAssistantEnrolledDevices")]
    public bool? RequireCompanyPortalOnSetupAssistantEnrolledDevices { get; set; }

    [JsonPropertyName("requiresUserAuthentication")]
    public bool? RequiresUserAuthentication { get; set; }

    [JsonPropertyName("restoreBlocked")]
    public bool? RestoreBlocked { get; set; }

    [JsonPropertyName("restoreCompletedScreenDisabled")]
    public bool? RestoreCompletedScreenDisabled { get; set; }

    [JsonPropertyName("restoreFromAndroidDisabled")]
    public bool? RestoreFromAndroidDisabled { get; set; }

    [JsonPropertyName("screenTimeScreenDisabled")]
    public bool? ScreenTimeScreenDisabled { get; set; }

    [JsonPropertyName("sharedIPadMaximumUserCount")]
    public int? SharedIPadMaximumUserCount { get; set; }

    [JsonPropertyName("simSetupScreenDisabled")]
    public bool? SimSetupScreenDisabled { get; set; }

    [JsonPropertyName("siriDisabled")]
    public bool? SiriDisabled { get; set; }

    [JsonPropertyName("softwareUpdateScreenDisabled")]
    public bool? SoftwareUpdateScreenDisabled { get; set; }

    [JsonPropertyName("supervisedModeEnabled")]
    public bool? SupervisedModeEnabled { get; set; }

    [JsonPropertyName("supportDepartment")]
    public string? SupportDepartment { get; set; }

    [JsonPropertyName("supportPhoneNumber")]
    public string? SupportPhoneNumber { get; set; }

    [JsonPropertyName("temporarySessionTimeoutInSeconds")]
    public int? TemporarySessionTimeoutInSeconds { get; set; }

    [JsonPropertyName("termsAndConditionsDisabled")]
    public bool? TermsAndConditionsDisabled { get; set; }

    [JsonPropertyName("touchIdDisabled")]
    public bool? TouchIdDisabled { get; set; }

    [JsonPropertyName("updateCompleteScreenDisabled")]
    public bool? UpdateCompleteScreenDisabled { get; set; }

    [JsonPropertyName("userSessionTimeoutInSeconds")]
    public int? UserSessionTimeoutInSeconds { get; set; }

    [JsonPropertyName("userlessSharedAadModeEnabled")]
    public bool? UserlessSharedAadModeEnabled { get; set; }

    [JsonPropertyName("watchMigrationScreenDisabled")]
    public bool? WatchMigrationScreenDisabled { get; set; }

    [JsonPropertyName("welcomeScreenDisabled")]
    public bool? WelcomeScreenDisabled { get; set; }

    [JsonPropertyName("zoomDisabled")]
    public bool? ZoomDisabled { get; set; }
}
