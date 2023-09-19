// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DepEnrollmentProfileModel
{
    [JsonPropertyName("appleIdDisabled")]
    public bool? AppleIdDisabled { get; set; }

    [JsonPropertyName("applePayDisabled")]
    public bool? ApplePayDisabled { get; set; }

    [JsonPropertyName("awaitDeviceConfiguredConfirmation")]
    public bool? AwaitDeviceConfiguredConfirmation { get; set; }

    [JsonPropertyName("configurationEndpointUrl")]
    public string? ConfigurationEndpointUrl { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("diagnosticsDisabled")]
    public bool? DiagnosticsDisabled { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enableAuthenticationViaCompanyPortal")]
    public bool? EnableAuthenticationViaCompanyPortal { get; set; }

    [JsonPropertyName("enableSharedIPad")]
    public bool? EnableSharedIPad { get; set; }

    [JsonPropertyName("iTunesPairingMode")]
    public DepEnrollmentProfileITunesPairingModeConstant? ITunesPairingMode { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("isMandatory")]
    public bool? IsMandatory { get; set; }

    [JsonPropertyName("locationDisabled")]
    public bool? LocationDisabled { get; set; }

    [JsonPropertyName("macOSFileVaultDisabled")]
    public bool? MacOSFileVaultDisabled { get; set; }

    [JsonPropertyName("macOSRegistrationDisabled")]
    public bool? MacOSRegistrationDisabled { get; set; }

    [JsonPropertyName("managementCertificates")]
    public List<ManagementCertificateWithThumbprintModel>? ManagementCertificates { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passCodeDisabled")]
    public bool? PassCodeDisabled { get; set; }

    [JsonPropertyName("profileRemovalDisabled")]
    public bool? ProfileRemovalDisabled { get; set; }

    [JsonPropertyName("requireCompanyPortalOnSetupAssistantEnrolledDevices")]
    public bool? RequireCompanyPortalOnSetupAssistantEnrolledDevices { get; set; }

    [JsonPropertyName("requiresUserAuthentication")]
    public bool? RequiresUserAuthentication { get; set; }

    [JsonPropertyName("restoreBlocked")]
    public bool? RestoreBlocked { get; set; }

    [JsonPropertyName("restoreFromAndroidDisabled")]
    public bool? RestoreFromAndroidDisabled { get; set; }

    [JsonPropertyName("sharedIPadMaximumUserCount")]
    public int? SharedIPadMaximumUserCount { get; set; }

    [JsonPropertyName("siriDisabled")]
    public bool? SiriDisabled { get; set; }

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
