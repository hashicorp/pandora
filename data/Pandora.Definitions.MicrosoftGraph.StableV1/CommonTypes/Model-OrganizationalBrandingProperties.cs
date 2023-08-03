// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class OrganizationalBrandingPropertiesModel
{
    [JsonPropertyName("backgroundColor")]
    public string? BackgroundColor { get; set; }

    [JsonPropertyName("backgroundImage")]
    public string? BackgroundImage { get; set; }

    [JsonPropertyName("backgroundImageRelativeUrl")]
    public string? BackgroundImageRelativeUrl { get; set; }

    [JsonPropertyName("bannerLogo")]
    public string? BannerLogo { get; set; }

    [JsonPropertyName("bannerLogoRelativeUrl")]
    public string? BannerLogoRelativeUrl { get; set; }

    [JsonPropertyName("cdnList")]
    public List<string>? CdnList { get; set; }

    [JsonPropertyName("customAccountResetCredentialsUrl")]
    public string? CustomAccountResetCredentialsUrl { get; set; }

    [JsonPropertyName("customCSS")]
    public string? CustomCSS { get; set; }

    [JsonPropertyName("customCSSRelativeUrl")]
    public string? CustomCSSRelativeUrl { get; set; }

    [JsonPropertyName("customCannotAccessYourAccountText")]
    public string? CustomCannotAccessYourAccountText { get; set; }

    [JsonPropertyName("customCannotAccessYourAccountUrl")]
    public string? CustomCannotAccessYourAccountUrl { get; set; }

    [JsonPropertyName("customForgotMyPasswordText")]
    public string? CustomForgotMyPasswordText { get; set; }

    [JsonPropertyName("customPrivacyAndCookiesText")]
    public string? CustomPrivacyAndCookiesText { get; set; }

    [JsonPropertyName("customPrivacyAndCookiesUrl")]
    public string? CustomPrivacyAndCookiesUrl { get; set; }

    [JsonPropertyName("customResetItNowText")]
    public string? CustomResetItNowText { get; set; }

    [JsonPropertyName("customTermsOfUseText")]
    public string? CustomTermsOfUseText { get; set; }

    [JsonPropertyName("customTermsOfUseUrl")]
    public string? CustomTermsOfUseUrl { get; set; }

    [JsonPropertyName("favicon")]
    public string? Favicon { get; set; }

    [JsonPropertyName("faviconRelativeUrl")]
    public string? FaviconRelativeUrl { get; set; }

    [JsonPropertyName("headerBackgroundColor")]
    public string? HeaderBackgroundColor { get; set; }

    [JsonPropertyName("headerLogo")]
    public string? HeaderLogo { get; set; }

    [JsonPropertyName("headerLogoRelativeUrl")]
    public string? HeaderLogoRelativeUrl { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("loginPageLayoutConfiguration")]
    public LoginPageLayoutConfigurationModel? LoginPageLayoutConfiguration { get; set; }

    [JsonPropertyName("loginPageTextVisibilitySettings")]
    public LoginPageTextVisibilitySettingsModel? LoginPageTextVisibilitySettings { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("signInPageText")]
    public string? SignInPageText { get; set; }

    [JsonPropertyName("squareLogo")]
    public string? SquareLogo { get; set; }

    [JsonPropertyName("squareLogoDark")]
    public string? SquareLogoDark { get; set; }

    [JsonPropertyName("squareLogoDarkRelativeUrl")]
    public string? SquareLogoDarkRelativeUrl { get; set; }

    [JsonPropertyName("squareLogoRelativeUrl")]
    public string? SquareLogoRelativeUrl { get; set; }

    [JsonPropertyName("usernameHintText")]
    public string? UsernameHintText { get; set; }
}
