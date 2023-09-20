// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IntuneBrandModel
{
    [JsonPropertyName("contactITEmailAddress")]
    public string? ContactITEmailAddress { get; set; }

    [JsonPropertyName("contactITName")]
    public string? ContactITName { get; set; }

    [JsonPropertyName("contactITNotes")]
    public string? ContactITNotes { get; set; }

    [JsonPropertyName("contactITPhoneNumber")]
    public string? ContactITPhoneNumber { get; set; }

    [JsonPropertyName("darkBackgroundLogo")]
    public MimeContentModel? DarkBackgroundLogo { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

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

    [JsonPropertyName("showDisplayNameNextToLogo")]
    public bool? ShowDisplayNameNextToLogo { get; set; }

    [JsonPropertyName("showLogo")]
    public bool? ShowLogo { get; set; }

    [JsonPropertyName("showNameNextToLogo")]
    public bool? ShowNameNextToLogo { get; set; }

    [JsonPropertyName("themeColor")]
    public RgbColorModel? ThemeColor { get; set; }
}
