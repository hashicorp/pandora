// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IntuneBrandModel
{
    [JsonPropertyName("companyPortalBlockedActions")]
    public List<CompanyPortalBlockedActionModel>? CompanyPortalBlockedActions { get; set; }

    [JsonPropertyName("contactITEmailAddress")]
    public string? ContactITEmailAddress { get; set; }

    [JsonPropertyName("contactITName")]
    public string? ContactITName { get; set; }

    [JsonPropertyName("contactITNotes")]
    public string? ContactITNotes { get; set; }

    [JsonPropertyName("contactITPhoneNumber")]
    public string? ContactITPhoneNumber { get; set; }

    [JsonPropertyName("customCanSeePrivacyMessage")]
    public string? CustomCanSeePrivacyMessage { get; set; }

    [JsonPropertyName("customCantSeePrivacyMessage")]
    public string? CustomCantSeePrivacyMessage { get; set; }

    [JsonPropertyName("customPrivacyMessage")]
    public string? CustomPrivacyMessage { get; set; }

    [JsonPropertyName("darkBackgroundLogo")]
    public MimeContentModel? DarkBackgroundLogo { get; set; }

    [JsonPropertyName("disableClientTelemetry")]
    public bool? DisableClientTelemetry { get; set; }

    [JsonPropertyName("disableDeviceCategorySelection")]
    public bool? DisableDeviceCategorySelection { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enrollmentAvailability")]
    public IntuneBrandEnrollmentAvailabilityConstant? EnrollmentAvailability { get; set; }

    [JsonPropertyName("isFactoryResetDisabled")]
    public bool? IsFactoryResetDisabled { get; set; }

    [JsonPropertyName("isRemoveDeviceDisabled")]
    public bool? IsRemoveDeviceDisabled { get; set; }

    [JsonPropertyName("landingPageCustomizedImage")]
    public MimeContentModel? LandingPageCustomizedImage { get; set; }

    [JsonPropertyName("lightBackgroundLogo")]
    public MimeContentModel? LightBackgroundLogo { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onlineSupportSiteName")]
    public string? OnlineSupportSiteName { get; set; }

    [JsonPropertyName("onlineSupportSiteUrl")]
    public string? OnlineSupportSiteUrl { get; set; }

    [JsonPropertyName("privacyUrl")]
    public string? PrivacyUrl { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("sendDeviceOwnershipChangePushNotification")]
    public bool? SendDeviceOwnershipChangePushNotification { get; set; }

    [JsonPropertyName("showAzureADEnterpriseApps")]
    public bool? ShowAzureADEnterpriseApps { get; set; }

    [JsonPropertyName("showConfigurationManagerApps")]
    public bool? ShowConfigurationManagerApps { get; set; }

    [JsonPropertyName("showDisplayNameNextToLogo")]
    public bool? ShowDisplayNameNextToLogo { get; set; }

    [JsonPropertyName("showLogo")]
    public bool? ShowLogo { get; set; }

    [JsonPropertyName("showNameNextToLogo")]
    public bool? ShowNameNextToLogo { get; set; }

    [JsonPropertyName("showOfficeWebApps")]
    public bool? ShowOfficeWebApps { get; set; }

    [JsonPropertyName("themeColor")]
    public RgbColorModel? ThemeColor { get; set; }
}
